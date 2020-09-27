<template>
  <q-layout view="hHh lpR fFf">

     <q-header class="q-py-sm" style="background-color: #1c1b21;" :style="'border-bottom: 2px solid '+ theme_color">
        <q-toolbar>
          <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="leftDrawerOpen = !leftDrawerOpen"
        />
        <img src='/statics/hawcomlogo.jpeg' width=40 height=40>
        <span :style="'font-size: 35px;color:'+theme_color" class="my-font text-h6 q-mr-md">Hawcom Ecosystem</span>
        <q-space ></q-space>
      <q-tabs v-model="selected_tab" shrink>

        <!-- <q-tab :style= "[selected_tab == 't_0' ? {backgroundColor: theme_color} : {}]" class="q-mr-sm q-py-xs custom_tab" @click="scrollToElement('id_about_us');" style="width:120px;min-height:auto !important;color: white" label="About Us" />
        <q-tab :style= "[selected_tab == 't_1' ? {backgroundColor: theme_color} : {}]" class="q-mr-sm q-py-xs custom_tab" @click="scrollToElement('id_services');" style="width:120px;min-height:auto !important;color: white" label="Services" />
        <q-tab :style= "[selected_tab == 't_2' ? {backgroundColor: theme_color} : {}]" class="q-mr-sm q-py-xs custom_tab" @click="scrollToElement('id_team');" style="min-height:auto !important;color: white" label="Team" />
        -->
        <q-btn 
        class="q-mr-md" 
        size="12px" 
        :style="'min-height:auto !important;background:'+ theme_color +'; color: white; padding:1px'" 
        dense icon="color_lens"
        @click="logoutUser">
            Logout
          </q-btn>
      </q-tabs> 
        
      </q-toolbar>
    </q-header>

    <q-drawer 
      v-model="leftDrawerOpen"
      :breakpoint="767"
      :width="200"
      bordered
      content-class="bg-primary"
    >
      <q-list dark>

         <q-item
           clickable
            @click="ToRegistrationAdmin"
            class="bg-primary text-white">
          <q-item-section avatar>
            <q-item-label>Registration Admin</q-item-label>
             <q-menu
                    v-if="RegistrationPermission"
                      fit>
                      <q-list dense class="text-grey-9 text-caption bg-primary">
                        <q-item
                            v-for="nav in registrationNavs"
                            :key="nav.label"
                            :to="nav.to"
                            clickable
                            class="bg-primary text-white">
                            <q-item-section avatar>
                            <q-item-label>{{ nav.label }}</q-item-label>
                            </q-item-section>
                            </q-item>
                      </q-list>
                    </q-menu>
                   
          </q-item-section>
        </q-item>

        <q-item
          clickable
          @click="ToAccountAdmin"
          class="bg-primary text-white">
          <q-item-section avatar>
            <q-item-label>Account Admin</q-item-label>
            <q-menu
                    v-if="AccountPermission"
                      fit>
                      <q-list dense class="text-grey-9 text-caption bg-primary">
                        <q-item
                            v-for="nav in accountNavs"
                            :key="nav.label"
                            :to="nav.to"
                            clickable
                            class="bg-primary text-white">
                            <q-item-section avatar>
                            <q-item-label>{{ nav.label }}</q-item-label>
                            </q-item-section>
                            </q-item>
                      </q-list>
              </q-menu>
                    
          </q-item-section>
        </q-item>

         <q-item
           clickable
            @click="ToRefugeCeneterAdmin"
            class="bg-primary text-white">
          <q-item-section avatar>
            <q-item-label>Refuge Ceneter Admin</q-item-label>
             <q-menu
                    v-if="RefugeCenterPermission"
                      fit>
                      <q-list dense class="text-grey-9 text-caption bg-primary">
                        <q-item
                            v-for="nav in refugeCenterNavs"
                            :key="nav.label"
                            :to="nav.to"
                            clickable
                            class="bg-primary text-white">
                            <q-item-section avatar>
                            <q-item-label>{{ nav.label }}</q-item-label>
                            </q-item-section>
                            </q-item>
                      </q-list>
                    </q-menu>
                   
          </q-item-section>
        </q-item>

         <q-item
          clickable
          @click="ToPishonAdmin"
          class="bg-primary text-white">
          <q-item-section avatar>
            <q-item-label>Pishon Admin</q-item-label>
            <q-menu
                    v-if="PishonPermission"
                      fit>
                      <q-list dense class="text-grey-9 text-caption bg-primary">
                        <q-item
                            v-for="nav in pishonNavs"
                            :key="nav.label"
                            :to="nav.to"
                            clickable
                            class="bg-primary text-white">
                            <q-item-section avatar>
                            <q-item-label>{{ nav.label }}</q-item-label>
                            </q-item-section>
                            </q-item>
                      </q-list>
              </q-menu>
                    
          </q-item-section>
        </q-item>

       

      </q-list>
    </q-drawer>

    <q-page-container>

      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>

export default {
  name: 'AdminLayout',
  computed: {
        IdentityModel() {
            return this.$store.getters['authenticationStore/IdentityModel'];
        },
        Loginstatus() {
          return this.$store.getters['authenticationStore/Loginstatus'];
        },
        theme_color(){
          return this.$store.getters['authenticationStore/theme_color'];
        },
        Admin(){
          return this.$store.getters['authenticationStore/Admin'];
        }
      },
  components: {

  },
  data () {
    return {
      leftDrawerOpen: true,
      RefugeCenterPermission: false,
      PishonPermission: false,
      AccountPermission: false,
      RegistrationPermission: false,
      registrationNavs: [
              {
                label:'Register Contributor',
                to:'/registeredContributors'
              }
        ],
      refugeCenterNavs: [
              {
                label:'Refuge Center Contributors',
                to:'/refugecenter'
              },
              {
                label: 'Confirmed Refuge Contributors',
                to: '/confirmedContributors'
              },
              {
                label:'Move Contributors to Pishon',
                to:'/toPishon'
              }
        ],
       pishonNavs: [
              {
                label:'Pishon Contributors',
                to:'/pishonContributors'
              },
              {
                label:'Confirm Pishon Level',
                to:'/confirmPishonLevel'
              },
              {
                label:'Move to Pishon Refuge',
                to:'/toPishonRefuge'
              }
        ],
        accountNavs: [
              {
                label:'Confirm Entry Payment',
                to:'/confirmEntryPayment'
              },
              {
                label:'Confirm Pishon Level Payment',
                to:'/confirmPishonLevelPayment'
              }
        ]
    }
  },
  methods:{
    logoutUser(){
      this.$store.dispatch('authenticationStore/Logout')
    },
    displayHomePage(){
      this.$router.push('/');
    },
    displayAboutUsPage(){
      this.$router.push('/about');
    },
    displayContactUsPage(){
      this.$router.push('/contact');
    },
    scrollToElement(identityvalue){
      if(identityvalue == 'id_about_us'){
        this.$router.push('/about');
      }

      if(identityvalue == 'id_services'){
        this.$router.push('/streams');
      }

      if(identityvalue == 'id_team'){
        this.$router.push('/team');
      }
    },
     ToRefugeCeneterAdmin(){
      var context = this;
      if(context.Admin.designation == "Refuge Center Admin" ||
        context.Admin.designation == "CEO")
      {
        context.RefugeCenterPermission = true;
      }
      else{
        context.RefugeCenterPermission = false;
        alert("You do not permission to work in refuge center department");
      }
    },
    ToPishonAdmin(){
       var context = this;
      if(context.Admin.designation == "Pishon Admin" ||
          context.Admin.designation == "CEO")
      {
        context.PishonPermission = true;
      }
      else{
        context.PishonPermission = false;
        alert("You do not permission to work in pishon department");
      }
    },
    ToAccountAdmin(){
       var context = this;
      if(context.Admin.designation == "Account Admin" ||
          context.Admin.designation == "CEO")
      {
        context.AccountPermission = true;
      }
      else{
        context.AccountPermission = false;
        alert("You do not permission to work in account department");
      }
    },
    ToRegistrationAdmin(){
      var context = this;
      if(context.Admin.designation == "Registration Admin" ||
          context.Admin.designation == "CEO")
      {
        context.RegistrationPermission = true;
      }
      else{
        context.RegistrationPermission = false;
        alert("You do not permission to work in registration department");
      }
    },
    ShowPage(designation){

      var context = this;

      if(designation == 'CEO'){
        
        if(context.Admin.designation == "Registration Admin"){
          console.log('CEO')
          this.$router.push('/registeredContributors');
        }
      }

      if(designation == 'Registration Admin'){
        

        if(context.Admin.designation == "Registration Admin"){
          console.log('Registration Admin')
          this.$router.push('/registeredContributors');
        }
      }

      if(designation == 'Confirm Payment Admin'){
        var context = this;

        if(context.Admin.designation == "Account Admin"){
          console.log('Account Admin')
          this.$router.push('/unconfirmedAccounts');
        }
        
      }

    /*   if(designation == 'Refuge Center Admin'){
        var context = this;

        if(context.Admin.designation == "Refuge Center Admin"){
          console.log('Refuge Center Admin')
          this.$router.push('/refugecenter');
        }
        
      } */
    }
  },
  created(){
    
  }
}
</script>

<style lang="sass">
    .main_line
      font-size: 75px;
      letter-spacing: 5px;
      line-height: 60px;
      font-weight: 600;

    .custom-caption
      text-align: center;
      padding: 12px;
      color: white;

    .animation_1
      -webkit-animation: bounceIn 1s ease-in 800ms both;
      animation: bounceIn 1s ease-in 800ms both;

    .animation_2
      -webkit-animation: flipInX 2s ease-in-out 800ms both;
      animation: flipInX 1s ease-in-out 800ms both;

    .animation_3
      -webkit-animation: lightSpeedIn 1s ease-in 800ms both;
      animation: lightSpeedIn 1s ease-in 800ms both;

    .description
      padding: 10px
      background-color: black
      color: white
      box-shadow: 1px 1px 2px #e6e6e6

    .my-header
      width: 200px
      top: 0
      height: 45px
      color: black
      background-color: rgba(255,255,255, 0.8)
      text-transform: uppercase
      text-align: center
      font-size: 17px
      margin: 20px 0 0 68px
      padding: 25px

    .my-text
      width: 100%
      top: 0
      height: 90px
      color: white
      text-align: center
      font-size: 15px
      margin: 79px 0 0 0
      padding: 20px
      line-height: normal
      font-family: Georgia, serif
      font-style: italic

    .my-button-container
      width: 100%

    .my-button
      text-decoration: none
      text-transform: uppercase
      margin: 0 0 20px 0
      text-align: center
      padding: 7px 14px
      background-color: #000
      color: #fff
      text-transform: uppercase
      box-shadow: 0 0 1px #000
      transition-delay: 0.2s

    .my-button:hover
      box-shadow: 0 0 5px #000

    .box-shadow:hover
      box-shadow: 0 10px 13px -6px rgba(0, 0, 0, 0.2), 0 20px 31px 3px rgba(0, 0, 0, 0.14), 0 8px 38px 7px rgba(0, 0, 0, 0.12) !important;

    .my-card
      width: 350px
      max-width: 350px
      margin-top: 10px

    .team-header
      width: 100%
      top: 0
      height: 45px
      color: white
      text-transform: uppercase
      text-align: center
      font-size: 17px
      margin: 60px 0 0 0
      padding: 12px

    .team-text
      width: 100%
      top: 0
      height: 90px
      color: white
      text-align: center
      font-size: 15px
      margin: 100px 0 0 0
      padding: 20px
      line-height: normal
      font-family: Georgia, serif
      font-style: italic
    
    .quote
      background: url(/statics/images/parallax.jpg);
      background-size: cover;
      background-position: center;
      background-attachment: fixed;
      background-repeat: no-repeat;
    
    .pricing
      background: url(/statics/images/pricing.jpg);
      background-size: cover;
      background-position: center;
      background-attachment: fixed;
      background-repeat: no-repeat;
    
    .contact_us
      background: url(/statics/images/contact_us.jpg);
      background-size: cover;
      background-position: center;
      background-attachment: fixed;
      background-repeat: no-repeat;
    
    .custom_tab
      width: 130px;
</style>