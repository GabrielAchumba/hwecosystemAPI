<template>
  <div>
    <div class="row text-center flex flex-center">
       <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
            <h5 class="text-center">Latest News
              <br>
              <span
                class="text-center text-grey text-h6">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</span>
            </h5>
          </div>
    </div>
            <div class="row text-center flex flex-center">
          <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-md flex flex-center">
            <div class="col-md-4 col-lg-4 col-sx-12 col-sm-12">
              <q-card @mouseover="hoverOver(1)" @mouseout="hoverOutTimeout(1)" style="border: none;" class="my-card text-center box-shadow" flat bordered>
                <q-img
                  src="/statics/images/about_1.jpg"
                />

                <q-card-section class="text-left">

                  <div :class="about_heading_1" :style="'color: ' + about_heading_color_1" class="about_heading_1 text-h6 q-mt-sm q-mb-xs">LATEST NEWS 1</div>
                  <div class="text-caption text-grey-9 q-mt-sm">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                  </div>
<div><br>
<q-btn size="sm" :style="'background:'+ theme_color +'; color: white'" label="READ MORE"/>
</div>
                </q-card-section>
              </q-card>
            </div>
            <div class="col-md-4 col-lg-4 col-sx-12 col-sm-12">
              <q-card @mouseover="hoverOver(2)" @mouseout="hoverOutTimeout(2)" :style="'color: ' + about_heading_color_2" style="border: none;" class="my-card text-center box-shadow" flat bordered>
                <q-img
                  src="/statics/images/about_2.jpg"
                />

                <q-card-section class="text-left">

                  <div :class="about_heading_2" :style="'color: ' + about_heading_color_2" class="text-h6 q-mt-sm q-mb-xs">LATEST NEWS 2</div>
                  <div class="text-caption text-grey-9 q-mt-sm">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                  </div>
<div><br>
<q-btn size="sm" :style="'background:'+ theme_color +'; color: white'" label="READ MORE"/>
</div>
                </q-card-section>
              </q-card>
            </div>
            <div class="col-md-4 col-lg-4 col-sx-12 col-sm-12">
              <q-card @mouseover="hoverOver(3)" @mouseout="hoverOutTimeout(3)" style="border: none;" class="my-card text-center box-shadow" flat bordered>
                <q-img
                  src="/statics/images/about_3.jpg"
                />

                <q-card-section class="text-left">

                  <div :class="about_heading_3" :style="'color: ' + about_heading_color_3" class="text-h6 q-mt-sm q-mb-xs">LATEST NEWS 3</div>
                  <div class="text-caption text-grey-9 q-mt-sm">
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore
                    et dolore magna aliqua.
                  </div>
<div><br>
<q-btn size="sm" :style="'background:'+ theme_color +'; color: white'" label="READ MORE"/>
</div>
                </q-card-section>
              </q-card>
            </div>
          </div>
        </div>
  </div>
</template>

<script>
import {QFlashcard, QFlashcardSection} from '@quasar/quasar-ui-qflashcard'

    export default {
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
            }
         },
        components: {
            QFlashcard,
            QFlashcardSection
        },
         props: {
            theme_color: {
                type: String,
                default: 'rgb(0, 163, 82)'
            },
            about_heading_1: {
                type: Array
            },
             about_heading_2: {
                type: Array
            },
             about_heading_3: {
                type: Array
            },
            about_heading_color_1: {
                type: String,
                default: '#424242'
            },
            about_heading_color_2: {
                type: String,
                default: '#424242'
            },
            about_heading_color_3: {
                type: String,
                default: '#424242'
            }
        },
        methods:{
              hoverOver: function(index) {
              this['about_heading_color_' + index] = this.theme_color;
              this['about_heading_' + index] = ['animated', 'bounceIn'];              
            },
            hoverOutTimeout: function(index) {
              this['about_heading_color_' + index] = '#424242';
              setTimeout(() => {
                this['about_heading_' + index] = [];                
              }, 1000);              
            }
        }
    }
</script>

<style>
</style>
