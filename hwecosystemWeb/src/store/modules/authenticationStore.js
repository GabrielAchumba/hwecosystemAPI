import { $http } from 'boot/axios' 

const state = {

    ExamScores: [0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100],
    IdentityModel:{},
    Admin: {},
    LoginDialog: false,
    Loginstatus: "Log in",
    Departments: [],
    theme_color: "rgb(0, 163, 82)",
    contributor: {},
    administrator: {},
    DoesNotHaveMoneyAccount: true,
    paystackkey: "",
    visible: false,
    showSimulatedReturnData: true,
  }

  const getters = {
    DoesNotHaveMoneyAccount(state){
      return state.DoesNotHaveMoneyAccount;
    },
    visible(state){
      return state.visible;
    },
    showSimulatedReturnData(state){
      return state.showSimulatedReturnData;
    },
    paystackkey(state){
      return state.paystackkey
    },
    administrator(state){
      return state.administrator;
    },
    contributor(state){
      return state.contributor;
    },
    theme_color(state){
      return state.theme_color;
    },
    AuthDTO(state){
      return state.AuthDTO;
    },
    ExamScores(state){
      return state.ExamScores;
    },
  IdentityModel (state) {
    return state.IdentityModel;
  },
  LoginDialog (state) {
    return state.LoginDialog;
  },
  Loginstatus (state) {
    return state.Loginstatus;
  },
  Departments(state){
    return state.Departments;
  },
  Admin(state){
    return state.Admin;
  }
}

const mutations = {
  GetAdmin(state, payload){
    state.Admin = payload;
  },
  Login(state, payload){
    console.log("Login")
    state.Loginstatus= "Log out";
    state.IdentityModel = payload.identityModel;
    state.contributor = payload.contributor;
    state.administrator = payload.administrator;
    state.paystackkey = payload.paystackkey;
    state.DoesNotHaveMoneyAccount = payload.doesNotHaveMoneyAccount;
    
    if(state.IdentityModel.userType == "admin"){
      this.$router.push('/admin');
    }
    else{
      this.$router.push('/home');
    }

    state.visible = false
    state.showSimulatedReturnData = true
    
  },
  Logout(state){
    console.log("logoutUser");
    state.Loginstatus= "Log in";
    state.IdentityModel = {}
    this.$router.push('/');
  },
  showLoginDialog(state){
    console.log("Show Log in Page");
    this.$router.push('/login');
  },
  hideLoginDialog(state){
    state.LoginDialog = false;
  },
  onFacultyValueChanged(state, payload){
    var selectedIndex = state.AuthDTO.Faculties.indexOf(payload);
    facultyObj=state.AuthDTO.facultiesObj[selectedIndex];
    state.Departments = [];

    var i = 0;
    for(i=0; i < state.AuthDTO.departmentsObj.length; i++){
        if(facultyObj.id == state.AuthDTO.departmentsObj.id){
          state.Departments.push(state.AuthDTO.departmentsObj[i].nameOfDepartment);
        }
    }
  }

}

const actions = {
  Login(context, payload)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.post('Auths/Login', payload)
        .then(response => {
            
          context.commit('Login', response.data) 
          context.dispatch('GetAdmin')             
            resolve(response)
            
        })
        .catch(error => {
          console.log("login error")
          state.visible = false
          state.showSimulatedReturnData = true
          alert("UserName or Password does not exist");
          reject(error)
        })
    })
  },
  Logout(context)
  {
    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.post('Auths/Logout', context.state.IdentityModel)
        .then(response => {
            
          context.commit('Logout', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          reject(error)
        })
    })
  },
  GetAdmin(context)
  {
    return new Promise((resolve, reject) => {
      console.log("GetAdmin")
       $http.get('Administrators/'+ context.state.IdentityModel.id)
        .then(response => {
            
          context.commit('GetAdmin', response.data)              
            resolve(response)
            
        })
        .catch(error => {
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