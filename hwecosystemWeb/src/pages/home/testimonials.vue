<template>
  <div>
     <div style="background-color: #000000ad !important;">
        <q-carousel
            v-model="review_slide"
            swipeable
            animated
            infinite
            autoplay
            arrows
            navigation
            padding
            navigation-position="bottom"
            class="text-white full-height bg-transparent q-mx-xl"
            >
            <q-carousel-slide style="padding-bottom: 140px" name="style" class="column no-wrap flex-center">
                <img :style="'margin-top:100px;border-radius:5px;border: 4px solid ' + theme_color" src="/statics/imagescopy/team_2.jpg" width=150 height=150>
            <div class="q-mt-md text-h6 text-center">
            <span :style="'color:'+theme_color">James Omeke</span><br><span class="text-overline">Managing Director</span>
            </div>
                <div class="q-mt-md text-h6 text-center">
                Lorem ipsum dolor sit amet, consectetur
        adipiscing elit, sed do eiusmod tempor incididunt ut<br>
        labore et dolore magna aliqua.
                </div>
            </q-carousel-slide>
            <q-carousel-slide style="padding-bottom: 140px" name="tv" class="column no-wrap flex-center">
                <img :style="'margin-top:100px;border-radius:5px;border: 4px solid ' + theme_color" src="/statics/imagescopy/team_3.jpg" width=150 height=150>
            <div class="q-mt-md text-h6 text-center">
            <span :style="'color:'+theme_color">James Chito</span><br><span class="text-overline">Business Director</span>
            </div>
                <div class="q-mt-md text-h6 text-center">
                Lorem ipsum dolor sit amet, consectetur
        adipiscing elit, sed do eiusmod tempor incididunt ut<br>
        labore et dolore magna aliqua.
                </div>
            </q-carousel-slide>
            <q-carousel-slide style="padding-bottom: 140px" name="layers" class="column no-wrap flex-center">
                <img :style="'margin-top:100px;border-radius:5px;border: 4px solid ' + theme_color" src="/statics/imagescopy/team_1.jpg" width=150 height=150>
            <div class="q-mt-md text-h6 text-center">
            <span :style="'color:'+theme_color">Gabriel Achumba</span><br><span class="text-overline">Technical Director</span>
            </div>
                <div class="q-mt-md text-h6 text-center">
                Lorem ipsum dolor sit amet, consectetur
        adipiscing elit, sed do eiusmod tempor incididunt ut<br>
        labore et dolore magna aliqua.
                </div>
            </q-carousel-slide>
            </q-carousel>
        </div>
  </div>
</template>

<script>

    export default {
        data() {
            return {
                review_slide: 'style'
            }
        },
        props: {
            theme_color: {
            type: String,
            default: 'rgb(0, 163, 82)'
            }
        }
    }
</script>

<style>
</style>
