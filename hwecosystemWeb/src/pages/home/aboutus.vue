<template>
  <div>
        <br>
        <div class="row">
            <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
              <h5 class="text-center">About Us
                <br>
                <span class="text-center text-grey text-h6">HAWcom is the operational subsidiary of <br>PORTHARCOURT HEALTH AND WEALTH COOPERATIVE INVESTMENT AND CREDIT SOCIETY</span>
              </h5>
            </div>
        </div>
        <br>

        <div class="row text-center flex flex-center">
          <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-md flex flex-center">
            <div class="col-md-4 col-lg-4 col-sx-12 col-sm-12">
              <q-card @mouseover="hoverOver(1)" @mouseout="hoverOutTimeout(1)" style="border: none;" class="my-card text-center box-shadow" flat bordered>
                <q-img
                  src="/statics/images/about_1.jpg"
                />
                

                <q-card-section>
                  <!-- <div class="text-overline text-orange-9">Overline</div> -->
                  <div :class="about_heading_1" :style="'color: ' + about_heading_color_1" class="about_heading_1 text-h6 q-mt-sm q-mb-xs">VISION</div>
                  <div class="text-caption text-grey-9">
                    One million people living together, succeeding together, every need met, no one lacking
                  </div>
                </q-card-section>
              </q-card>
            </div>
            <div class="col-md-4 col-lg-4 col-sx-12 col-sm-12">
              <q-card @mouseover="hoverOver(2)" @mouseout="hoverOutTimeout(2)" :style="'color: ' + about_heading_color_2" style="border: none;" class="my-card text-center box-shadow" flat bordered>
                <q-img
                  src="/statics/images/about_2.jpg"
                />
                <q-card-section>
                  <!-- <div class="text-overline text-orange-9">Overline</div> -->
                  <div :class="about_heading_2" :style="'color: ' + about_heading_color_2" class="text-h6 q-mt-sm q-mb-xs">MISSION</div>
                  <div class="text-caption text-grey-9">
                   We are a community of people living together, succeeding together, every need met, no one lacking
                  </div>
                </q-card-section>
              </q-card>
            </div>
            <div class="col-md-4 col-lg-4 col-sx-12 col-sm-12">
              <q-card @mouseover="hoverOver(3)" @mouseout="hoverOutTimeout(3)" style="border: none;" class="my-card text-center box-shadow" flat bordered>
                <q-img
                  src="/statics/images/about_3.jpg"
                />
                

                <q-card-section>
                  <!-- <div class="text-overline text-orange-9">Overline</div> -->
                  <div :class="about_heading_3" :style="'color: ' + about_heading_color_3" class="text-h6 q-mt-sm q-mb-xs">VALUES</div>
                  <div :class="about_heading_3" :style="'color: ' + about_heading_color_3" class="text-h6 q-mt-sm q-mb-xs">FIICC</div>
                  <div class="text-caption text-grey-9">
                    freedom, integrity, inter-dependence, community, common wealth
                  </div>
                </q-card-section>
              </q-card>
            </div>
          </div>
        </div>
  </div>
</template>

<script>

    export default {
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
