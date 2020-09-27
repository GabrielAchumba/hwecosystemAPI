<template>
  <q-layout view="lHh lpr lFf">
    <q-header class="q-py-sm" style="background-color: #1c1b21;" :style="'border-bottom: 2px solid '+ theme_color">
        <q-toolbar>
        <img src='/statics/hawcomlogo.jpeg' width=40 height=40>
        <span :style="'font-size: 35px;color:'+theme_color" class="my-font text-h6 q-mr-md">Hawcom Ecosystem</span>
        <q-space ></q-space>

        <q-btn 
        class="q-mr-md" 
        :style="'width:120px; min-height:auto !important;color: white; background:'+ theme_color +'; padding:1px'" 
        dense
        @click="scrollToElement('id_loginregister');" >
            Login/Register
          </q-btn>
        
      <q-tabs v-model="selected_tab" shrink>

        <q-tab 
        :style= "[selected_tab == 't_0' ? {backgroundColor: theme_color} : {}]" 
        class="q-mr-sm q-py-xs custom_tab" 
        @click="scrollToElement('id_about_us');" 
        style="width:120px;min-height:auto !important;color: white" 
        label="About Us" />
        <q-tab :style= "[selected_tab == 't_1' ? {backgroundColor: theme_color} : {}]" class="q-mr-sm q-py-xs custom_tab" @click="scrollToElement('id_services');" style="width:120px;min-height:auto !important;color: white" label="Streams" />
        <q-tab :style= "[selected_tab == 't_2' ? {backgroundColor: theme_color} : {}]" class="q-mr-sm q-py-xs custom_tab" @click="scrollToElement('id_team');" style="min-height:auto !important;color: white" label="Team" />
    
<!--           <a style="font-size: 25px;" class="float-right q-mr-sm" href="https://github.com/sponsors/mayank091193"
           target="_blank" title="Donate"><i class="fas fa-heart" style="color: #eb5daa"></i></a> -->
      </q-tabs>
        
      </q-toolbar>
    </q-header>
    <q-page-container>
      <q-page>
        <q-carousel
          animated
          v-model="slide"
          arrows
          swipeable
          navigation
          infinite
          autoplay
          control-color="white"
          transition-prev="slide-right"
          transition-next="slide-left"
          height="639px"
        >
          <q-carousel-slide class="q-pa-none" :name="1" img-src="/statics/images/image_1.jpg">
<div class="full-height full-width flex flex-center" style="background-color: rgba(0, 0, 0, 0.68) !important;">
            <div class="custom-caption">
              <div class="text-h2 main_line animation_2">WELCOME TO <span :style="'color:'+theme_color">HAWCOM ECOSYSTEM</span></div><br><br><br>
              <div class="text-h4 animation_1">We are a crowd funding platform.</div><br><br><br>
<!-- <div class="animation_2">
<q-btn size="md" :style="'background:'+ theme_color +'; color: white'" label="READ MORE"/>
</div> -->
            </div>
</div>
          </q-carousel-slide>
          <q-carousel-slide class="q-pa-none" :name="2" img-src="/statics/images/image_2.jpg">
<div class="full-height full-width flex flex-center" style="background-color: rgba(0, 0, 0, 0.68) !important;">
            <div class="custom-caption">
    	      <div class="text-h2 main_line animation_2" style="font-size:65px;"><span :style="'color:'+theme_color">HAWCOM ECOSYSTEM</span> FOR THE BEST</div><br><br><br>
              <div class="text-h4 animation_1">We must overcome greed, falsehood,<br>and remain faithful to one another in the ecosystem.</div><br><br><br>
<!-- <div class="animation_2">
<q-btn size="md" :style="'background:'+ theme_color +'; color: white'" label="READ MORE"/>
</div> -->
            </div>
</div>
          </q-carousel-slide>
          <q-carousel-slide class="q-pa-none" :name="3" img-src="/statics/images/image_3.jpg">
<div class="full-height full-width flex flex-center" style="background-color: rgba(0, 0, 0, 0.68) !important;">
            <div class="custom-caption">
    	      <div class="text-h2 main_line animation_2" style="font-size:65px;">THE PATH OF <span :style="'color:'+theme_color">SUCCESS</span></div><br><br><br>
              <div class="text-h4 animation_1">Every one of us will attain financial freedom <br> and we will be able to fulfill destiny.</div><br><br><br>
<!-- <div class="animation_2">
<q-btn size="md" :style="'background:'+ theme_color +'; color: white'" label="READ MORE"/>
</div> -->
            </div>
</div>
          </q-carousel-slide>
        </q-carousel>

         <div class="row">
          <div class="col-md-3 col-lg-3 col-xs-12 col-sm-12">
            <q-card class="q-pa-sm flex flex-center text-center box-shadow" style="margin: 40px;">


              <q-card-section>
                <q-icon size="110px" name="ballot" :style="'color:'+theme_color"/>
                <div class="text-h6">Level 1</div>

              </q-card-section>

              <q-card-section class="q-pt-none">
                Contributor (PISHON Stream) receive ₦1,500 after the completion of Level 1. This Level has 3 descendants.
              </q-card-section>
            </q-card>
          </div>
          <div class="col-md-3 col-lg-3 col-xs-12 col-sm-12">
            <q-card class="q-pa-sm flex flex-center text-center box-shadow" style="margin: 40px;">


              <q-card-section>
                <q-icon size="110px" name="view_comfy" :style="'color:'+theme_color"/>
                <div class="text-h6">Level 2</div>

              </q-card-section>

              <q-card-section class="q-pt-none">
                 Contributor (PISHON Stream) receive ₦3,600 after the completion of Level 2. This Level has 9 descendants.
              </q-card-section>
            </q-card>
          </div>
          <div class="col-md-3 col-lg-3 col-xs-12 col-sm-12">
            <q-card class="q-pa-sm flex flex-center text-center box-shadow" style="margin: 40px;">


              <q-card-section>
                <q-icon size="110px" name="people" :style="'color:'+theme_color"/>
                <div class="text-h6">Level 3</div>

              </q-card-section>

              <q-card-section class="q-pt-none">
                Contributor (PISHON Stream) receive ₦8,100 after the completion of Level 3. This Level has 27 descendants.
              </q-card-section>
            </q-card>
          </div>

          <div class="col-md-3 col-lg-3 col-xs-12 col-sm-12">
            <q-card class="q-pa-sm flex flex-center text-center box-shadow" style="margin: 40px;">


              <q-card-section>
                <q-icon size="110px" name="people" :style="'color:'+theme_color"/>
                <div class="text-h6">Level 4</div>

              </q-card-section>

              <q-card-section class="q-pt-none">
                Contributor (PISHON Stream) receive ₦16,200 after the completion of Level 4. This Level has 81 descendants.
              </q-card-section>
            </q-card>
          </div>
        </div>

        <br>
        <br>

         <div class="row">
          <div class="col-md-3 col-lg-3 col-xs-12 col-sm-12">
            <q-card class="q-pa-sm flex flex-center text-center box-shadow" style="margin: 40px;">


              <q-card-section>
                <q-icon size="110px" name="ballot" :style="'color:'+theme_color"/>
                <div class="text-h6">Level 5</div>

              </q-card-section>

              <q-card-section class="q-pt-none">
                Contributor (PISHON Stream) receive ₦24,300 after the completion of Level 5. This Level has 243 descendants.
              </q-card-section>
            </q-card>
          </div>
          <div class="col-md-3 col-lg-3 col-xs-12 col-sm-12">
            <q-card class="q-pa-sm flex flex-center text-center box-shadow" style="margin: 40px;">


              <q-card-section>
                <q-icon size="110px" name="view_comfy" :style="'color:'+theme_color"/>
                <div class="text-h6">Level 6</div>

              </q-card-section>

              <q-card-section class="q-pt-none">
                Contributor (PISHON Stream) receive ₦36,450 after the completion of Level 6. This Level has 729 descendants.
              </q-card-section>
            </q-card>
          </div>
          <div class="col-md-3 col-lg-3 col-xs-12 col-sm-12">
            <q-card class="q-pa-sm flex flex-center text-center box-shadow" style="margin: 40px;">


              <q-card-section>
                <q-icon size="110px" name="people" :style="'color:'+theme_color"/>
                <div class="text-h6">Level 7</div>

              </q-card-section>

              <q-card-section class="q-pt-none">
                Contributor (PISHON Stream) receive ₦54,675 after the completion of Level 7. This Level has 2187 descendants.
              </q-card-section>
            </q-card>
          </div>

        </div>


        <div class="quote">
          <div class="q-pt-xl full-width full-height flex flex-center" style="background-color: #000000ad !important;">
            <h3 class="text-white text-center">This is HEALTHY AND WEALTHY COMMUNITY (HAWcom) ecosystem <br> expressed in an MLM for I million people and more.
              <br>
              <br>
              
            </h3>
          </div>
        </div>


        <div class="row" id="id_about_us">
          <aboutus-app
          :theme_color="theme_color"
          :about_heading_1="about_heading_1"
          :about_heading_2="about_heading_2"
          :about_heading_3="about_heading_3"
          :about_heading_color_1="about_heading_color_1"
          :about_heading_color_2="about_heading_color_2"
          :about_heading_color_3="about_heading_color_3"></aboutus-app>
        </div>

        <br>
        <br>
        <div style="background: #f7f7f7" id="id_services">
          <services-app
          :theme_color="theme_color"></services-app>    
        </div>

       <!--  <div class="quote" id="id_testimonial">
          <testimonials-app
          :theme_color="theme_color"></testimonials-app> 
        </div> -->

        <div class="row" id="id_team">
        <teams-app
          :active="active"
          :background_style="background_style"
          :theme_color="theme_color"
          :hover="hover"></teams-app>     
        </div>


        
         <!--  <div class="pricing" id="id_pricing">
            <pricing-app
          :active="active"
          :background_style="background_style"
          :theme_color="theme_color"
          :hover="hover"></pricing-app>   
         </div> -->

<!-- <div class="row" id="id_news">
         <news-app
         :theme_color="theme_color"
          :about_heading_1="about_heading_1"
          :about_heading_2="about_heading_2"
          :about_heading_3="about_heading_3"
          :about_heading_color_1="about_heading_color_1"
          :about_heading_color_2="about_heading_color_2"
          :about_heading_color_3="about_heading_color_3"
         ></news-app>
        </div> -->
        <br>
        <br>
        <div id="id_loginregister">
        <loginregister-app
        :theme_color="theme_color"></loginregister-app>
        </div>
    
        <br>
        <br>
        <div class="contact_us" id="id_contact_us">
        <contactus-app
        :theme_color="theme_color"></contactus-app>
        </div>
        
<footer-app
:theme_color="theme_color"></footer-app>

      </q-page>
    </q-page-container>
  </q-layout>
</template>

<style src="@quasar/quasar-ui-qflashcard/dist/index.css"></style>

<script>
  import { scroll } from 'quasar'
  const { getScrollTarget, setScrollPosition } = scroll
    
    import {QFlashcard, QFlashcardSection} from '@quasar/quasar-ui-qflashcard'
    import portfolio from 'pages/home/portfolio.vue';
    import aboutus from 'pages/home/aboutus.vue';
    import services from 'pages/home/services.vue';
    import testimonials from 'pages/home/testimonials.vue'
    import teams from 'pages/home/teams.vue'
    import pricing from 'pages/home/pricing.vue'
    import news from 'pages/home/news.vue'
    import contactus from 'pages/home/contactus.vue'
    import footer from 'pages/home/footer.vue'
    import loginregister from 'pages/authentication/loginregister.vue'
    

    export default {
        components: {
            QFlashcard,
            QFlashcardSection,
            'portfolio-app': portfolio,
            'aboutus-app': aboutus,
            'services-app': services,
            'testimonials-app': testimonials,
            'teams-app': teams,
            'pricing-app': pricing,
            'news-app': news,
            'contactus-app': contactus,
            'footer-app': footer,
            'loginregister-app': loginregister
        },
        data() {
            return {
                slide: 1,
		            review_slide: 'style',
                selected_tab: 't_0',
                team_slide: 1,
                bg_color: 'rgb(0, 163, 82)',
                hover: false,
                active: false,
                theme_color: 'rgb(0, 163, 82)',
                background_style: 'background-color:rgba(0, 163, 82, 0.7);',
                about_heading_1: [],
                about_heading_2: [],
                about_heading_3: [],
                about_heading_color_1: '#424242',
                about_heading_color_2: '#424242',
                about_heading_color_3: '#424242'
            }
        },
        computed: {
            style() {
                return {
                    width: '340px',
                    height: '263px',
                    backgroundImage: `url('https://raw.githubusercontent.com/quasarframework/quasar-ui-qflashcard/dev/demo/src/statics/bgimg.jpg')`, // eslint-disable-line
                    textAlign: 'center',
                    boxShadow: '1px 1px 2px #e6e6e6',
                    display: 'inline-block'
                }
            },
            team_style() {
                return {
                    width: '260px',
                    height: '263px',
                    backgroundImage: `url('https://raw.githubusercontent.com/quasarframework/quasar-ui-qflashcard/dev/demo/src/statics/bgimg.jpg')`, // eslint-disable-line
                    textAlign: 'center',
                    boxShadow: '1px 1px 2px #e6e6e6',
                    display: 'inline-block'
                }
            }
        },
        methods: {
          Login(){
            this.$store.commit('authenticationStore/showLoginDialog')
          },
          scrollToElement (id) {
            let el = document.getElementById(id)
            const target = getScrollTarget(el)
            const offset = el.offsetTop + 3
            const duration = 900
            setScrollPosition(target, offset, duration)
          },
            changeBgColor() {
                this.theme_color = this.bg_color;
                this.background_style = 'background-color:' + this.bg_color.split(')')[0] + ',0.7)';
            },
            hoverOver: function(index) {
              this['about_heading_color_' + index] = this.theme_color;
              this['about_heading_' + index] = ['animated', 'bounceIn'];              
            },
            hoverOutTimeout: function(index) {
              this['about_heading_color_' + index] = '#424242';
              setTimeout(() => {
                this['about_heading_' + index] = [];                
              }, 1000);              
            },
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

