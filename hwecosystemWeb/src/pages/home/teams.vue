<template>
  <div>
     <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12 flex flex-center">
              <h5 class="text-center">Our Team
                <br>
              </h5>
            </div>
               
          <div class="row text-center flex flex-center">
            <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-px-xl" style="width:100%;overflow:auto;">
              <q-carousel
              v-model="team_slide"
              transition-prev="slide-right"
              transition-next="slide-left"
              swipeable
              animated
	      infinite
              autoplay
              control-color="primary"
              navigation
              padding
              height="300px"
              class="rounded-borders"
            >
              <q-carousel-slide v-for="val in [1,2,3,4]" :key="val" :name="val" class="column no-wrap">
                <div class="row fit justify-center items-center q-gutter-xs q-col-gutter no-wrap">
                  <span v-for="teamData in teamsData" :key="teamData.index">
                  <q-flashcard :no-hover="hover" :style="team_style">
                    <q-flashcard-section transition="['nudge-out', 'fade-out']" :active="active">
                      <img :src="'/statics/imagescopy/team_'+teamData.index+'.jpg'" width=260 height=263>
                    </q-flashcard-section>
                    <q-flashcard-section transition="fade-in" class="fit" :active="active">
                      <div class="fit" :style="background_style"></div>
                      <q-flashcard-section 
                      transition="shake-down" class="text-center team-header" :active="active">
                        {{ teamData.fullName }}
                      </q-flashcard-section>

                      <q-flashcard-section transition="spin-in" class="team-text" :active="active">
                          {{ teamData.designation }}
                      </q-flashcard-section>
                      <q-flashcard-section style="padding-bottom: 50px" transition="slide-up-in" class="fit flex justify-center items-end"
                                           :active="active">
                        <q-btn class="q-mr-md" :style="'color:'+theme_color" style="background-color:white" round
                               icon="card_giftcard"/>
                        <q-btn :style="'color:'+theme_color" style="background-color:white" round icon="link"/>
                      </q-flashcard-section>
                    </q-flashcard-section>
                  </q-flashcard>
                  </span>
                </div>
              </q-carousel-slide>
            </q-carousel>
            </div>
          </div>
  </div>
</template>

<script>
import {QFlashcard, QFlashcardSection} from '@quasar/quasar-ui-qflashcard'

    export default {
         computed: {
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
        components: {
            QFlashcard,
            QFlashcardSection
        },
        data() {
            return {
                team_slide: 1,
                 teamsData : [
                   {
                        index:1,
                        fullName:"Gabriel Achumba",
                        designation: "Lead Software Development"
                    }, 
                    {
                        index:2,
                        fullName:"Humphrey Nsirim",
                        designation: "Global Ambassador and CEO"
                    },
                    {
                        index:3,
                        fullName:"Ikwo Nnachi",
                        designation: "Governing Team Member, Quality Assurance and Control"
                    },
                    {
                        index:4,
                        fullName:"Catherine N. Nsirim",
                        designation: "Governing Team Member, Head of Accounts Team"
                    }
                    ]
            }
        },
        props: {
            hover: {
            type: Boolean,
            default: false
            },
            background_style: {
            type: String,
            default: 'background-color:rgba(0, 163, 82, 0.7);'
            },
            theme_color: {
            type: String,
            default: 'rgb(0, 163, 82)'
            }, 
            active: {
            type: Boolean,
            default: false
            },
        },
        methods: {

        }
    }
</script>

