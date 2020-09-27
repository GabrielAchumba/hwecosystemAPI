<template>
  <div class="q-pa-md">
    <div class="q-gutter-y-md">
      <q-card>
        <q-tabs
          v-model="tab"
          dense
          class="text-grey"
          active-color="primary"
          indicator-color="primary"
          align="justify"
          narrow-indicator
          
        >
          <q-tab @click="changeTab('login')"
          name="login" label="Login" />
          <q-tab @click="changeTab('register')"
          name="register" label="Register/Update Profile" />
        </q-tabs>

        <q-separator />

        <q-tab-panels v-model="tab" animated>
          <q-tab-panel name="login">
            <login-app></login-app>

          </q-tab-panel>

          <q-tab-panel name="register">
            <register-app></register-app>
          </q-tab-panel>
        </q-tab-panels>

      </q-card>

    </div>
  </div>
</template>

<script>
import login from 'pages/authentication/login.vue'
import register from 'pages/authentication/register.vue' 
export default {
    computed: {
          tab(){
              return this.$store.getters['clientStore/tab'];
          }
    },
    components: {
            'login-app': login,
            'register-app': register
        },
  data () {
    return {
      
    }
  },
  methods: {
    changeTab(tabname){
      console.log(tabname)
      this.$store.commit('clientStore/commitTab', tabname)
    }
  },
  created(){
    //this.$store.commit('clientStore/commitTab')
  }
}
</script>