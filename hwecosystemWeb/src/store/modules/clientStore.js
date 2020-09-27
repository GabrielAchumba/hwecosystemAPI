import { $http } from 'boot/axios' 

const state = {
    PersonalDataDTO:{
      title:"",
      firstName:"",
      middleName:"",
      lastName:"",
      gender:"",
      userName:"",
      password:"",
      birthDay:23,
      birthMonth: 8,
      birthYear: 2020,
      parentUserName:"",
      createdDay:23,
      createdMonth: 8,
      createdYear: 2020
    },
    BioDataDTO:{
      bloodGroup:"",
      genotype:"",
      maritalStatus:"",
      lGAOfOrigin:"",
      stateOfOrigin:"",
      country:"",
      base64String:""
    },
    ContactDTO:{
      phoneNumber:"",
      email:"",
      address:"",
      residentialCity:"",
      residentialState:""
    },
    NextOfKinDTO:{
      nOKNames:"",
      nOKAddress:"",
      nOKPhoneNumber:"",
      nOKRelationship:""
    },
    BankAccountDTO: {
      bankName: "",
      accountName: "",
      accountNumber: "",
      bVN: ""
    },
    genders: ["Male", "Female"],
    base64String:"",
    step: 1,
    UploadProgress: "0%",
    RegisteredContributors: [],
    visible: false,
    showSimulatedReturnData: true,
    date: '2019/03/01',
    tab: "login"

  }

  const getters = {
    tab(state){
      return state.tab;
    },
    date(state){
      return state.date;
    },
    visible(state){
      return state.visible;
    },
    showSimulatedReturnData(state){
      return state.showSimulatedReturnData;
    },
    PersonalDataDTO (state) {
    return state.PersonalDataDTO;
  },
  BioDataDTO (state) {
    return state.BioDataDTO;
  },
  ContactDTO (state) {
    return state.ContactDTO;
  },
  NextOfKinDTO (state) {
    return state.NextOfKinDTO;
  },
  BankAccountDTO(){
    return state.BankAccountDTO;
  },
  genders (state) {
    return state.genders;
  },
  base64String(state){
    return state.base64String;
  },
  step(state){
    return state.step;
  },
  UploadProgress(state){
    return state.UploadProgress;
  },
  RegisteredContributors(state){
    return state.RegisteredContributors;
  }
}

const mutations = {
  commitTab(state, payload){
    state.tab = payload;
  },
  GetRegisteredContributors(state, payload){
    state.RegisteredContributors = payload;
    state.visible = false
    state.showSimulatedReturnData = true
  },
  CommitDataOfBirth(state, payload){

    state.date = payload;
    console.log(payload)

    var DOB = new Date(payload);
    console.log(DOB)
  

    state.PersonalDataDTO.birthYear = DOB.getFullYear();
    state.PersonalDataDTO.birthMonth = DOB.getMonth() + 1;
    state.PersonalDataDTO.birthDay= DOB.getDate();

    console.log(state.PersonalDataDTO)
  },
  CreatePersonalDataDTO(state, payload){
        state.PersonalDataDTO = payload;
        state.visible = false
    state.showSimulatedReturnData = true
  },
  UpdateContactDTO(state, payload){
    state.ContactDTO = payload
    state.visible = false
    state.showSimulatedReturnData = true
  },
  UpdateBioData(state, payload){
    state.BioDataDTO = payload
    state.visible = false
    state.showSimulatedReturnData = true
  },
  UpdateNextOfKinDTO(state, payload){
    state.NextOfKinDTO = payload
    state.visible = false
    state.showSimulatedReturnData = true
  },
  UpdateBankAccountData(state, payload){
    state.BankAccountDTO = payload
    state.visible = false
    state.showSimulatedReturnData = true
  },
  backstep(state, payload){
    state.step = payload
  },
  GetUploadProgress(state, payload){
    state.UploadProgress = payload;
  },
  UploadFile(state, payload){
    state.base64String = payload;
    console.log(state.base64String); 
  }
}

const actions = {
  CreatePersonalDataDTO(context, payload)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

    var todayDate = new Date();
    context.state.PersonalDataDTO.createdYear = todayDate.getFullYear();
    context.state.PersonalDataDTO.createdMonth = todayDate.getMonth() + 1;
    context.state.PersonalDataDTO.createdDay= todayDate.getDate();

    return new Promise((resolve, reject) => {
       $http.post('Contributors/CreatePersonalDataDTO', context.state.PersonalDataDTO)
        .then(response => {
            
          context.commit('CreatePersonalDataDTO', response.data) 
          if(!response.data){
            alert("Personal data not registered. Please check entered data")
          }else{
            context.state.step = payload + 1; 
          }
                     
            resolve(response)
            
        })
        .catch(error => {   
          state.visible = false
          state.showSimulatedReturnData = true
          alert("User already exists");
          reject(error)
        })
    })
  },
  UpdateContactDTO(context, payload)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

    return new Promise((resolve, reject) => {
       $http.put('Contributors/UpdateContactDTO/' + context.state.PersonalDataDTO.id, context.state.ContactDTO)
        .then(response => {
            
          context.commit('UpdateContactDTO', response.data)  
          if(!response.data){
            alert("Contact data not registered. Please check entered data")
          }else{
            context.state.step = payload + 1; 
          }             
            resolve(response)
            
        })
        .catch(error => {  
          state.visible = false
          state.showSimulatedReturnData = true
          reject(error)
        })
    })
  },
  UploadPhoto(context, payload)
  {

    return new Promise((resolve, reject) => {
      $http.post('Contributors/UploadPhoto', payload, {
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
          reject(error)
        })
    })
  },
  UpdateBioData(context, payload)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

    context.state.BioDataDTO.base64String = context.state.base64String

    return new Promise((resolve, reject) => {
      
       $http.put('Contributors/UpdateBioData/' + context.state.PersonalDataDTO.id, context.state.BioDataDTO)
        .then(response => {
            
          context.commit('UpdateBioData', response.data) 
          if(!response.data){
            alert("Bio data not registered. Please check entered data")
          }else{
            context.state.step = payload + 1; 
          }               
            resolve(response)
            
        })
        .catch(error => {  
          state.visible = false
          state.showSimulatedReturnData = true
          reject(error)
        })
    })
  },
  UpdateNextOfKinDTO(context, payload)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

    return new Promise((resolve, reject) => {
       $http.put('Contributors/UpdateNextOfKinDTO/' + context.state.PersonalDataDTO.id, context.state.NextOfKinDTO)
        .then(response => {
            
          context.commit('UpdateNextOfKinDTO', response.data)    
          if(!response.data){
            alert("Next of kin data not registered. Please check entered data")
          }else{
            context.state.step = payload + 1; 
          }             
            resolve(response)
            
        })
        .catch(error => {  
          state.visible = false
          state.showSimulatedReturnData = true
          reject(error)
        })
    })
  },
  UpdateBankAccountData(context)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

    return new Promise((resolve, reject) => {
       $http.put('Contributors/UpdateBankAccountData/' + context.state.PersonalDataDTO.id, context.state.BankAccountDTO)
        .then(response => {
            
          context.commit('UpdateBankAccountData', response.data)
          if(!response.data){
            alert("Bank Account data not registered. Please check entered data")
          }else{
            context.state.tab = "login";
          }             
            resolve(response)
            
        })
        .catch(error => {  
          state.visible = false
          state.showSimulatedReturnData = true
          reject(error)
        })
    })
  },
  GetRegisteredContributors(context)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.get('Contributors')
        .then(response => {
            
          context.commit('GetRegisteredContributors', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          console.log("GetRegisteredContributors error")
          state.visible = false
          state.showSimulatedReturnData = true
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