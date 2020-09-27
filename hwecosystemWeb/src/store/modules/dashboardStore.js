import { $http } from 'boot/axios' 

const state = {
    Cycles:[],
    DescendantDTO: {},
    fAQs: [
      {
        question: "What is HAWcom crowd funding ecosystem all about?",
        answer: "Creating a space and environment where people can live together, succeed together, " +
                "every need met, no one lacking is possible. Yes we can! You have just joined that community"
      },
      {
        question: "How do I become a member?",
        answer: "You register as a member of the cooperative with ₦2,000 only so you can access other " +
                "benefits. Then you make your contributions depending on the stream you are entering."
      },
      {
        question: "What is my money used for?",
        answer: "We are a cooperative, where people live together, succeed together, every need met, no one lacking. " +
                 "We sustain the investing on real estate, trade the financial market. We also own our shop/business " +
                 "center where members buy t distributors or whole sale price."
      },
      {
        question: "What else can I enjoy as a member?",
        answer: "Life insurance cover worth ₦250,000 only. Skills that can set you up in life. You receive some " +
                "house hold gifts and food items."
      },
      {
        question: "What if I don't want to continue anymore?",
        answer: "We wish that all continue until you become financially free but you have the final say."
      },
      {
        question: "What if I'm not able to get 3 persons to be under me?",
        answer: "You will not receive any reward at all"
      },
      {
        question: "What is initial community offer (ICO)?",
        answer: "This is the entry contribution you make that allows you to begin to benefit from the whole system."
      },
      {
        question: "What is community recommittmrnt offer (CRO)?",
        answer: "This is the sustainability plan of the ecosystem where evvery member contributes towards the sustainability " +
                "of the system"
      },
      {
        question: "If I get more than 3 persons to be part of this programme, will there be any other benefits?",
        answer: "Yes, your circling out health gift will reflect your labour. That is if you get 5 persons extra to be involved " +
                "in the programme, your circling out healthy gift cannot be the same as somebody who brings 20 persons into the system."
      }
    ]
  }

  const getters = {
    Cycles(state){
        return state.Cycles;
    },
    DescendantDTO(state){
        return state.DescendantDTO;
    },
    fAQs(state){
      return state.fAQs;
    }
}

const mutations = {

    GetCyclesWithLevelsByUserId(state, payload){
    console.log("GetCyclesWithLevelsByUserId")
    state.Cycles = payload;
  },
  GetDesendantsPerLevel(state, payload){
    console.log("GetDesendantsPerLevel")
    state.DescendantDTO = payload;
  },
  GetPishonLevels(state, payload){
    console.log("GetPishonLevels")
    state.Cycles = payload;
  }

}

const actions = {

GetCyclesWithLevelsByUserId(context)
  {
    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.get('Cycles/GetCyclesWithLevelsByUserId')
        .then(response => {
            
          context.commit('GetCyclesWithLevelsByUserId', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          console.log("GetCyclesWithLevelsByUserId error")
          reject(error)
        })
    })
  },
  GetPishonLevels(context)
  {
    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.get('Cycles/GetPishonLevels')
        .then(response => {
            
          context.commit('GetPishonLevels', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          console.log("GetCyclesWithLevelsByUserId error")
          reject(error)
        })
    })
  },
  GetDesendantsPerLevel(context, payload)
  {

    return new Promise((resolve, reject) => {
      console.log("seen")
       $http.post('Contributors/GetDescendantsByLevel', payload)
        .then(response => {
            
          context.commit('GetDesendantsPerLevel', response.data)              
            resolve(response)
            
        })
        .catch(error => {
          console.log("GetDesendantsPerLevel error")
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