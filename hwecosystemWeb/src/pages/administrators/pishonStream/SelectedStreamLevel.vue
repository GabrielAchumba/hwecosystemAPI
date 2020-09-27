<template>
<div>

<div v-show="showSimulatedReturnData">
<div class="row text-center flex flex-center q-pb-lg">


<div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
 <div class="q-pa-md" style="font-family: Lato;">
  
  <q-card class="q-pa-sm q-gutter-sm"> 

            <q-card-section class="bg-primary text-white">
            <div class="row text-center flex flex-center q-pb-lg">
              <div class="col-md-2 col-lg-2 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
              </div>
               <div class="col-md-8 col-lg-8 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                 <p>{{ SelectedStreamLevel.fullName }} (Pishon Stream)</p>
               </div>
                
                <div class="col-md-2 col-lg-2 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                </div>
                
            </div>

          </q-card-section>

          <q-card-section>
            <div class="row text-center flex flex-center q-pb-lg">

                <div class="col-md-2 col-lg-2 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none"></div>
              <div class="col-md-8 col-lg-8 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">

                  <span class="text-h6">Please confirm {{ SelectedStreamLevel.levelName}} </span>
                  <br>
                  <br>
                  <q-btn class="text-capitalize" 
                            exact
                            size="sm" style="width:75px" dense label="Comfirm Level"
                        type="button"
                        color="primary"
                        @click="UpdatePishonLevelX" />
                  <br>
                  
              </div>

              <div class="col-md-2 col-lg-2 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none"></div>

            </div>

          </q-card-section>


         

      </q-card>
      
  </div>
</div>

</div>

</div>
<q-inner-loading :showing="visible">
        <q-spinner-gears size="50px" color="primary" />
      </q-inner-loading>
  </div>
</template>

<script>
  export default {
      computed: {
        SelectedStreamLevel(){
            return this.$store.getters['administratorStore/SelectedStreamLevel'];
        },
         visible(){
          return this.$store.getters['administratorStore/visible'];
        },
        showSimulatedReturnData(){
          return this.$store.getters['administratorStore/showSimulatedReturnData'];
        }
      },
    data() {
      return {


      }
    },
    methods: {
      UpdatePishonLevelX(){
        this.$store.dispatch('administratorStore/UpdatePishonLevelX')
      }
    },
    created() {

    }
  }
</script>