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

        <q-tab :style= "[selected_tab == 't_0' ? {backgroundColor: theme_color} : {}]" class="q-mr-sm q-py-xs custom_tab" @click="scrollToElement('id_about_us');" style="width:120px;min-height:auto !important;color: white" label="About Us" />
        <q-tab :style= "[selected_tab == 't_1' ? {backgroundColor: theme_color} : {}]" class="q-mr-sm q-py-xs custom_tab" @click="scrollToElement('id_services');" style="width:120px;min-height:auto !important;color: white" label="Services" />
        <q-tab :style= "[selected_tab == 't_2' ? {backgroundColor: theme_color} : {}]" class="q-mr-sm q-py-xs custom_tab" @click="scrollToElement('id_team');" style="min-height:auto !important;color: white" label="Team" />
        <!-- <q-btn 
        class="q-mr-md" 
        size="12px" 
        :style="'min-height:auto !important;background:'+ theme_color +'; color: white; padding:1px'" 
        dense icon="color_lens"
        @click="logoutUser">
            Logout
          </q-btn> -->

          <q-btn
          @click="toggleButton" 
          avatar>
            <q-avatar
			color="white" text-color="primary">
  	        {{ contributor.firstName.charAt(0) }}
  	      </q-avatar>
          <q-menu
            fit>
                      <q-list dense class="text-grey-9 text-caption bg-primary">
                        <q-item
                            class="bg-primary text-white">
                            <q-item-section avatar>
                            <div class="row text-center flex flex-center q-pb-lg">
                              <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                              <div 
                              class="q-pa-md" style="font-family: Lato;" 
                              avatar>
                                <q-avatar
                              color="white" text-color="primary">
                                    {{ contributor.firstName.charAt(0) }}
                                  </q-avatar>
                              </div>
                              <div 
                              class="q-pa-md" style="font-family: Lato;">
                                <p
                              color="white" text-color="primary">
                                    {{ contributor.firstName }} {{ contributor.lastName }}
                                  </p>
                              </div>
                              </div>
                            </div>
                            </q-item-section>
                            </q-item>

                            <q-item
                            class="bg-primary text-white">
                            <q-item-section avatar>
                            <div class="row text-center flex flex-center q-pb-lg">
                              <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                                <q-btn 
                                  class="q-mr-md" 
                                  size="12px" 
                                  :style="'min-height:auto !important;background:'+ theme_color +'; color: white; padding:1px'" 
                                  dense icon="color_lens"
                                  @click="logoutUser">
                                      Logout
                                    </q-btn>
                              </div>
                              </div>
                            </div>
                            </q-item-section>
                            </q-item>
                      </q-list>
              </q-menu>
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
        v-for="nav in navs"
        :key="nav.label"
        :to="nav.to"
        class="text-grey-4"
        exact
        clickable>
        <q-item-section avatar>
          <q-icon :name="nav.icon"/>
        </q-item-section>
        <q-item-section avatar>
          <q-item-label>{{ nav.label }}</q-item-label>
        </q-item-section>
        </q-item>

      </q-list>
    </q-drawer>

    <q-page-container>
      <q-dialog v-model="IsPaymentSuccessful">
          <paymentresponse-app></paymentresponse-app>
        </q-dialog>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import paymentresponse from 'pages/contribution/paymentresponse.vue';

export default {
  //name: 'AdminLayout',
  computed: {
        IdentityModel() {
            return this.$store.getters['authenticationStore/IdentityModel'];
        },
        contributor(){
          return this.$store.getters['authenticationStore/contributor'];
        },
        Loginstatus() {
          return this.$store.getters['authenticationStore/Loginstatus'];
        },
        theme_color(){
          return this.$store.getters['authenticationStore/theme_color'];
        },
        IsPaymentSuccessful(){
          return this.$store.getters['accountStore/IsPaymentSuccessful'];
        }
      },
  components: {
    'paymentresponse-app': paymentresponse

  },
  data () {
    return {
      leftDrawerOpen: true,
      showAccountDetails: false,
       navs: [
              {
                label:'Contribution',
                icon: 'group',
                to:'/contribution'
              },
              {
                label:'Dashboard',
                icon: 'school',
                to:'/dashboard'
              },
              {
                label:'FAQs',
                icon: 'school',
                to:'/faqs'
              }
      ]
    }
  },
  methods:{
    toggleButton(){
      var context = this;

      if(context.showAccountDetails == true){
        context.showAccountDetails = false;
      }else{
        context.showAccountDetails = true;
      }
    },
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