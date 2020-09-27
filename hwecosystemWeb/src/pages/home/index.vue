<template>
  <div>
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
  </div>
</template>

<script>
export default {
  computed: {
        theme_color(){
          return this.$store.getters['authenticationStore/theme_color'];
        }
      },
  data () {
    return {
      slide: 1
    }
  },
  created(){
    //this.$store.dispatch('authenticationStore/LoadList');
    
  }
}
</script>

<style scoped>
   
</style>