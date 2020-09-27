import { $http } from 'boot/axios' 

const state = {
    SortModels: [],
    SortVariable: {
        schoolName: "",
        isSchoolNameSelected: false,
        finalOverallGrade: "",
        isFinalOverallGradeSelected: false,
        schoolCategory: "",
        isSchoolCategorySelected: false,
        level: "",
        islevelSelected: false,
        subject: "",
        isSubjectSelected: false,
        grade: "",
        isGradeSelected: false,
        score: "0",
        scoreEnd: "100",
        isScoreSelected: false,
        examType: "",
        isExamTypeSelected: false,
        gender: "",
        isGenderSelected: false,
        lGAOfOrigin: "",
        isLGAOfOriginSelected: false
    },
    IsColumnsSelected: {
      fullNameSelected: true,
      subjectSelected: true,
      scoreSelected: true,
      gradeSelected: true,
      levelSelected: true,
      schoolNameSelected: true,
      schoolCategorySelected: true,
      lGASelected: true,
      examTypeSelected: true,
      finalOverallGradeSelected: true,
      genderSelected: true
      
    },
    SecondaryCutOffs: [],
    PrimaryCutOffs: [],
    SelectedPrimaryCutOff: {},
    SelectedSecondaryCutOff: {},
    PrimaryOptionCutOffCDialog: false,
    SecondaryOptionCutOffCDialog: false,
    PrimaryOptionCutOffUDialog: false,
    SecondaryOptionCutOffUDialog: false,
    refugeCentersDTO: {},
    pishonDTO: {},
    ConfirmedRefugeCenterDTO: {},
    SelectedStreamLevel: {},
    PishonDTOs: [],
    visible: false,
    showSimulatedReturnData: false,

  }

  const getters = {
    visible(state){
      return state.visible;
    },
    showSimulatedReturnData(state){
      return state.showSimulatedReturnData;
    },
    PishonDTOs(state){
      return state.PishonDTOs;
    },
    SelectedStreamLevel(state){
      return state.SelectedStreamLevel;
    },
    pishonDTO(state){
      return state.pishonDTO;
    },
    ConfirmedRefugeCenterDTO(state){
      return state.ConfirmedRefugeCenterDTO;
    },
    PrimaryOptionCutOffUDialog(state){
      return state.PrimaryOptionCutOffUDialog;
    },
    SecondaryOptionCutOffUDialog(state){
      return state.SecondaryOptionCutOffUDialog;
    },
    PrimaryOptionCutOffCDialog(state){
      return state.PrimaryOptionCutOffCDialog;
    },
    SecondaryOptionCutOffCDialog(state){
      return state.SecondaryOptionCutOffCDialog;
    },
    SecondaryCutOffs(state){
      return state.SecondaryCutOffs;
    },
    PrimaryCutOffs(state){
      return state.PrimaryCutOffs;
    },
    SelectedPrimaryCutOff(state){
      return state.SelectedPrimaryCutOff;
    },
    SelectedSecondaryCutOff(state){
      return state.SelectedSecondaryCutOff;
    },
    SortModels (state) {
    return state.SortModels;
  },
  SortVariable (state){
      return state.SortVariable;
  },
  IsColumnsSelected(state){
    return state.IsColumnsSelected;
  },
  refugeCentersDTO(state){
    return state.refugeCentersDTO;
  }
}

const mutations = {
  GetSelectedStreamLevel(state, payload){
    state.SelectedStreamLevel = payload;
    this.$router.push('/selectedStreamLevel')
  },
  GetSelectedStreamLevelNotPaid(state, payload){
    state.SelectedStreamLevel = payload;
    this.$router.push('/selectedPishonStreamLevelNotPaid')
  },
  ReadSortModels(state, payload){
    state.SortModels = payload
    this.$router.push('/admin');
  },
  ReadPrimaryOptionCutOff(state, payload){
    state.PrimaryCutOffs = payload;
  },
  CreatePrimaryOptionCutOff(state, payload){
    state.PrimaryCutOffs = payload;
    state.PrimaryOptionCutOffCDialog = false;
  },
  UpdatePrimaryOptionCutOff(state, payload){
    state.PrimaryCutOffs = payload;
    state.PrimaryOptionCutOffUDialog = false;
  },
  DeletePrimaryOptionCutOff(state, payload){
    state.PrimaryCutOffs = payload;
  },
  ReadSecondaryOptionCutOff(state, payload){
    state.SecondaryCutOffs = payload;
  },
  CreateSecondaryOptionCutOff(state, payload){
    state.SecondaryCutOffs = payload;
    state.SecondaryOptionCutOffCDialog = false;
  },
  UpdateSecondaryOptionCutOff(state, payload){
    state.SecondaryCutOffs = payload;
    state.SecondaryOptionCutOffUDialog = false;
  },
  DeleteSecondaryOptionCutOff(state, payload){
    state.SecondaryCutOffs = payload;
  },
  ShowPrimaryOptionCutOffCDialog(state){
    state.PrimaryOptionCutOffCDialog = true;
    console.log(state.PrimaryOptionCutOffCDialog)
  },
  ShowPrimaryOptionCutOffUDialog(state, payload){
    state.SelectedPrimaryCutOff = payload
    state.PrimaryOptionCutOffUDialog = true;
  },
  HidePrimaryOptionCutOffCDialog(state){
    state.PrimaryOptionCutOffCDialog = false;
  },
  HidePrimaryOptionCutOffUDialog(state){
    state.PrimaryOptionCutOffUDialog = false;
  },
  ShowSecondaryOptionCutOffCDialog(state){
    state.SecondaryOptionCutOffCDialog = true;
  },
  ShowSecondaryOptionCutOffUDialog(state, payload){
    state.SelectedSecondaryCutOff = payload;
    state.SecondaryOptionCutOffUDialog = true;
  },
  HideSecondaryOptionCutOffCDialog(state){
    state.SecondaryOptionCutOffCDialog = false;
  },
  HideSecondaryOptionCutOffUDialog(state){
    state.SecondaryOptionCutOffUDialog = false;
  },
  GetRefugeCenterDTO(state, payload){
    state.refugeCentersDTO = payload;
    state.visible = false
    state.showSimulatedReturnData = true
  },
  MoveRefugeeToPishon(state, payload){
    state.refugeCentersDTO = payload;
    state.visible = false
    state.showSimulatedReturnData = true
  },
  GetPishonDTO(state, payload){
    state.pishonDTO =  payload;
    state.visible = false
    state.showSimulatedReturnData = true
  },
  GetConfirmedRefugeCenterDTO(state, payload){
    state.ConfirmedRefugeCenterDTO = payload;
    state.visible = false
    state.showSimulatedReturnData = true
  },
  AddToPishon(state, payload){
    state.refugeCentersDTO = payload;
    state.visible = false
    state.showSimulatedReturnData = true
  },
  FetchPishonDTO(state, payload){
    state.PishonDTOs = payload;
    state.visible = false
    state.showSimulatedReturnData = true
  },
  UpdatePishonLevelX(state, payload){
    state.PishonDTOs = payload;
    this.$router.push('/confirmPishonLevel')
    state.visible = false
    state.showSimulatedReturnData = true
  },
  FetchPishonDTONotPaid(state, payload){
    state.PishonDTOs = payload;
    state.visible = false
    state.showSimulatedReturnData = true
  },
  UpdatePishonLevelXNotPaid(state, payload){
    state.PishonDTOs = payload;
    this.$router.push('/confirmPishonLevelPayment')
    state.visible = false
    state.showSimulatedReturnData = true
  }
  
}

const actions = {
  AddToPishon(context)
    {
      context.state.visible = true
    context.state.showSimulatedReturnData = false

      var recentRefugee = context.state.refugeCentersDTO.refugeCenterModels[0];
      return new Promise((resolve, reject) => {
        $http.post('RefugeCenters/AddToPishon', recentRefugee)
          .then(response => {
              
            //context.commit('SetColumns');
            context.commit('AddToPishon', response.data);
                        
              resolve(response)
              
          })
          .catch(error => {
            state.visible = false
          state.showSimulatedReturnData = true     
            reject(error)
          })
      })
    },
  FetchPishonDTO(context, payload)
    {
      context.state.visible = true
    context.state.showSimulatedReturnData = false

      return new Promise((resolve, reject) => {
        $http.get('Pishons/FetchPishonDTO/' + payload)
          .then(response => {
              
            //context.commit('SetColumns');
            context.commit('FetchPishonDTO', response.data);
                        
              resolve(response)
              
          })
          .catch(error => {  
            state.visible = false
          state.showSimulatedReturnData = true  
            reject(error)
          })
      })
    },
    FetchPishonDTONotPaid(context, payload)
    {
      context.state.visible = true
    context.state.showSimulatedReturnData = false

      return new Promise((resolve, reject) => {
        $http.get('Pishons/FetchPishonDTONotPaid/' + payload)
          .then(response => {
              
            //context.commit('SetColumns');
            context.commit('FetchPishonDTONotPaid', response.data);
                        
              resolve(response)
              
          })
          .catch(error => {   
            state.visible = false
          state.showSimulatedReturnData = true 
            reject(error)
          })
      })
    },
    UpdatePishonLevelX(context){
      context.state.visible = true
    context.state.showSimulatedReturnData = false

      return new Promise((resolve, reject) => {
        $http.post('Pishons/UpdatePishonLevelX', context.state.SelectedStreamLevel)
          .then(response => {
              
            //context.commit('SetColumns');
            context.commit('UpdatePishonLevelX', response.data);
                        
              resolve(response)
              
          })
          .catch(error => {   
            state.visible = false
          state.showSimulatedReturnData = true 
            reject(error)
          })
      })
    },
    UpdatePishonLevelXNotPaid(context){
      context.state.visible = true
    context.state.showSimulatedReturnData = false

      return new Promise((resolve, reject) => {
        $http.post('Pishons/UpdatePishonLevelXNotPaid', context.state.SelectedStreamLevel)
          .then(response => {
              
            //context.commit('SetColumns');
            context.commit('UpdatePishonLevelXNotPaid', response.data);
                        
              resolve(response)
              
          })
          .catch(error => {   
            state.visible = false
          state.showSimulatedReturnData = true 
            reject(error)
          })
      })
    },
  GetRefugeCenterDTO(context)
    {
      context.state.visible = true
    context.state.showSimulatedReturnData = false

      return new Promise((resolve, reject) => {
        $http.get('RefugeCenters/GetRefugeCenterDTO')
          .then(response => {
              
            //context.commit('SetColumns');
            context.commit('GetRefugeCenterDTO', response.data);
                        
              resolve(response)
              
          })
          .catch(error => {   
            state.visible = false
          state.showSimulatedReturnData = true 
            reject(error)
          })
      })
    },
  GetConfirmedRefugeCenterDTO(context)
  {
    context.state.visible = true
    context.state.showSimulatedReturnData = false

      return new Promise((resolve, reject) => {
        $http.get('RefugeCenters/GetConfirmedRefugeCenterDTO')
          .then(response => {
              
            //context.commit('SetColumns');
            context.commit('GetConfirmedRefugeCenterDTO', response.data);
                        
              resolve(response)
              
          })
          .catch(error => { 
            state.visible = false
          state.showSimulatedReturnData = true   
            reject(error)
          })
      })
    },
    MoveRefugeeToPishon(context)
    {
      context.state.visible = true
    context.state.showSimulatedReturnData = false

      return new Promise((resolve, reject) => {
        $http.get('RefugeCenters/MoveRefugeeToPishon')
          .then(response => {
              
            //context.commit('SetColumns');
            
            context.commit('MoveRefugeeToPishon', response.data);
                        
              resolve(response)
              
          })
          .catch(error => { 
            state.visible = false
          state.showSimulatedReturnData = true  
            reject(error)
          })
      })
    },
    GetPishonDTO(context)
    {
      context.state.visible = true
      context.state.showSimulatedReturnData = false

      return new Promise((resolve, reject) => {
        $http.get('Pishons/GetPishonDTO')
          .then(response => {
              
            //context.commit('SetColumns');
            context.commit('GetPishonDTO', response.data);
                        
              resolve(response)
              
          })
          .catch(error => {   
            state.visible = false
          state.showSimulatedReturnData = true
            reject(error)
          })
      })
    },
    ReadSortModels(context)
    {
      return new Promise((resolve, reject) => {
         $http.post('SortModels/GetSortedTable', state.SortVariable)
          .then(response => {
              
            //context.commit('SetColumns');
            context.commit('ReadSortModels', response.data);
                         
              resolve(response)
              
          })
          .catch(error => {   
            reject(error)
          })
      })
    },
    ReadPrimaryOptionCutOff(context){
      return new Promise((resolve, reject) => {
        $http.get('PrimaryCutOffs')
         .then(response => {

           context.commit('ReadPrimaryOptionCutOff', response.data);
                        
             resolve(response)
             
         })
         .catch(error => {   
           reject(error)
         })
     })
    },
    CreatePrimaryOptionCutOff(context, payload){
      return new Promise((resolve, reject) => {
        $http.post('PrimaryCutOffs', payload)
         .then(response => {
             
           context.commit('CreatePrimaryOptionCutOff', response.data);
                        
             resolve(response)
             
         })
         .catch(error => {   
           reject(error)
         })
     })
    },
    UpdatePrimaryOptionCutOff(context, payload){
      return new Promise((resolve, reject) => {
        $http.put('PrimaryCutOffs/' + payload.id, payload)
         .then(response => {
             
           context.commit('UpdatePrimaryOptionCutOff', response.data);
                        
             resolve(response)
             
         })
         .catch(error => {   
           reject(error)
         })
     })
    },
    DeletePrimaryOptionCutOff(context, payload){
      return new Promise((resolve, reject) => {
        $http.delete('PrimaryCutOffs/' + payload.id)
         .then(response => {
             
           context.commit('DeletePrimaryOptionCutOff', response.data);
                        
             resolve(response)
             
         })
         .catch(error => {   
           reject(error)
         })
     })
    },
    ReadSecondaryOptionCutOff(context){
      return new Promise((resolve, reject) => {
        $http.get('SecondaryCutOffs')
         .then(response => {
             
           context.commit('ReadSecondaryOptionCutOff', response.data);
                        
             resolve(response)
             
         })
         .catch(error => {   
           reject(error)
         })
     })
    },
    CreateSecondaryOptionCutOff(context, payload){
      return new Promise((resolve, reject) => {
        $http.post('SecondaryCutOffs', payload)
         .then(response => {
             
           context.commit('CreateSecondaryOptionCutOff', response.data);
                        
             resolve(response)
             
         })
         .catch(error => {   
           reject(error)
         })
     })
    },
    UpdateSecondaryOptionCutOff(context, payload){
      return new Promise((resolve, reject) => {
        $http.put('SecondaryCutOffs/'+payload.id, payload)
         .then(response => {
             
           context.commit('UpdateSecondaryOptionCutOff', response.data);
                        
             resolve(response)
             
         })
         .catch(error => {   
           reject(error)
         })
     })
    },
    DeleteSecondaryOptionCutOff(context, payload){
      return new Promise((resolve, reject) => {
        $http.delete('SecondaryCutOffs/'+ payload.id)
         .then(response => {
             
           context.commit('DeleteSecondaryOptionCutOff', response.data);
                        
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