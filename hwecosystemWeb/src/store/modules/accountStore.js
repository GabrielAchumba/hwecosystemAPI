import { $http } from 'boot/axios' 

const state = {
    Account:{
        base64String: ""
    },
    UploadProgress: "0%",
    base64String:"",
    responseMessage: "",
    accountDTO: {},
    SelectedAccount: {},
    levelDTO: {},
    IsPaymentSuccessful: false,
    paymentResponse: {},
    visible: false,
    showSimulatedReturnData: false,
    HasNotPaid: true
  }

  const getters = {
    HasNotPaid(state){
      return state.HasNotPaid;
    },
    visible(state){
      return state.visible;
    },
    showSimulatedReturnData(state){
      return state.showSimulatedReturnData;
    },
    paymentResponse(state){
      return state.paymentResponse;
    },
    IsPaymentSuccessful(state){
      return state.IsPaymentSuccessful;
    },
    SelectedAccount(state){
      return state.SelectedAccount;
    },
    Account(state){
        return state.Account;
    },
    UploadProgress(state){
      return state.UploadProgress;
    },
    base64String(state){
        return state.base64String;
    },
    responseMessage(state){
        return state.responseMessage;
    },
    accountDTO(state){
      return state.accountDTO;
    },
    levelDTO(state){
      return state.levelDTO;
    }
}

const mutations = {
  GetPaymentResponse(state, payload) { 
    state.paymentResponse = payload;
  },
    UpdateIsPaymentSuccessful(state, payload){
      state.IsPaymentSuccessful = payload;
    },
    HidepaymentresponseDialog(){
      state.IsPaymentSuccessful =  false;
      this.$router.push('/contribution');
    },
    SetSelectedAccount(state, payload){
      state.SelectedAccount = payload;
      this.$router.push('/comfirmPayment');
    },
    Payment(state, payload){
    console.log("Payment")
    state.Account = payload;
    if(state.base64String === ""){
        state.responseMessage = "No payment made"
    } 
    else{
        state.responseMessage = "Payment made. Please wait for less than 24 hours for payment to be comfirmed. Thanks"
    }
    state.HasNotPaid = false;
    this.$router.push('/home');
  },
  OffPlatformPayment(state, payload){
    console.log("Payment")
    state.Account = payload;
    /* if(state.base64String === ""){
        state.responseMessage = "No payment made"
    } 
    else{
        state.responseMessage = "Payment made. Please wait for less than 24 hours for payment to be comfirmed. Thanks"
    } */
    state.HasNotPaid = false;
    this.$router.push('/home');
  },
  GetUnComfirmedAccounts(state, payload){
    console.log("GetUnComfirmedAccounts")
    state.visible = false
    state.showSimulatedReturnData = true
    state.accountDTO = payload;
  },
  ComfirmPayment(state, payload){
    console.log("ComfirmPayment")
    state.accountDTO = payload;
    this.$router.push('/confirmEntryPayment');
    state.visible = false
    state.showSimulatedReturnData = true
  },
  GetUploadProgress(state, payload){
    state.UploadProgress = payload;
  },
  UploadFile(state, payload){
    state.base64String = payload;
    alert("Evidence of payment uploaded successfully");
    console.log(state.base64String); 
  },
  GetLevelsByIndex(state, payload){
    state.levelDTO = payload;
  },
  SetIsPaid(state, payload){
    
  }

}

const actions = {
    UploadPhoto(context, payload)
    {
  
      return new Promise((resolve, reject) => {
        $http.post('Accounts/UploadPhoto', payload, {
          onUploadProgress: uploadEvent => {
            context.commit('GetUploadProgress', Math.round(uploadEvent.loaded / uploadEvent.total * 100) + '%');
            
           
          }
        })
          .then(response => {
            
            console.log(response.data); 
            context.commit('UploadFile', response.data);
            console.log('UploadFile');               
              resolve(response)
              
          })
          .catch(error => {
            alert("Uploading of evidence of payment was not successful");
            reject(error)
          })
      })
    },
 Payment(context, payload)
  {
    var paydata = {
      message: context.state.paymentResponse.message,
      reference: context.state.paymentResponse.reference,
      status: context.state.paymentResponse.status,
      trans: context.state.paymentResponse.trans,
      transactions: context.state.paymentResponse.transaction,
      trxref: context.state.paymentResponse.trxref,
      contributor_Id: payload.id
    }

    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.post('Accounts/Payment', paydata)
        .then(response => {
            
          context.commit('Payment', response.data) 
          context.commit('HidepaymentresponseDialog')             
            resolve(response)
            
        })
        .catch(error => {
          alert("Confirmation of payment was unsuccesful. Please try again")
          context.commit('HidepaymentresponseDialog')   
          console.log("payment error")
          reject(error)
        })
    })
  },
  OffPlatformPayment(context, payload)
  {
      context.state.Account.base64String =  context.state.base64String;
      context.state.Account.contributor_Id = payload;
    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.post('Accounts/OffPlatformPayment', context.state.Account)
        .then(response => {
            
          context.commit('OffPlatformPayment', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          alert("Confirmation of payment was unsuccesful. Please try again")
          console.log("payment error")
          reject(error)
        })
    })
  },
  GetUnComfirmedAccounts(context)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.get('Accounts/GetUnComfirmedAccounts')
        .then(response => {
            
          context.commit('GetUnComfirmedAccounts', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          console.log("GetUnComfirmedAccounts error")
          state.visible = false
          state.showSimulatedReturnData = true
          reject(error)
        })
    })
  },
  ComfirmPayment(context)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.put('Accounts/ComfirmPayment/' + context.state.SelectedAccount.accountId, context.state.SelectedAccount)
        .then(response => {
            
          context.commit('ComfirmPayment', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          console.log("ComfirmPayment error")
          state.visible = false
          state.showSimulatedReturnData = true
          reject(error)
        })
    })
  },
  GetLevelsByIndex(context, payload)
  {
    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.get('Levels/GetLevelsByIndex/' + payload)
        .then(response => {
            
          context.commit('GetLevelsByIndex', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          console.log("GetLevelsByIndex error")
          reject(error)
        })
    })
  },
  SetIsPaid(context, payload)
  {
    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.put('Levels/SetIsPaid/' + payload.contributorLevelId, payload)
        .then(response => {
            
          context.commit('SetIsPaid', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          console.log("GetLevelsByIndex error")
          reject(error)
        })
    })
  }

}

export default {
  namespaced: true,
  getters,
  mutations,
  actions,
  state
}