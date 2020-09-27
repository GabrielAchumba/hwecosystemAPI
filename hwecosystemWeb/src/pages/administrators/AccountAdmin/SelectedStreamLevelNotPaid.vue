<template>
<div>

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
                  <div class="row text-center flex flex-center q-pb-lg">
                    <div class="col-md-6 col-lg-6 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                      <q-btn class="text-capitalize" 
                            exact
                            size="sm" dense label="Comfirm Level Payment"
                        type="button"
                        color="primary"
                        @click="UpdatePishonLevelX" />
                    </div>
  
                    <!-- <div class="col-md-2 col-lg-2 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none"></div> -->
                    <div class="col-md-6 col-lg-6 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                      <q-btn class="text-capitalize" 
                            exact
                            size="sm" dense label="Cancel"
                        type="button"
                        color="primary"
                        @click="cancel" />
                    </div>
                  </div>
            
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
</template>

<script>
  export default {
      computed: {
        SelectedStreamLevel(){
            return this.$store.getters['administratorStore/SelectedStreamLevel'];
        }
      },
    data() {
      return {


      }
    },
    methods: {
      UpdatePishonLevelX(){
        confirm("I hope you have paid user of his level entitlement." + "\n" + 
        "Once you click 'Ok', you cannot undo it") &&
          this.UpdatePishonLevelXPrivate()
      },
      UpdatePishonLevelXPrivate(){
        this.$store.dispatch('administratorStore/UpdatePishonLevelXNotPaid')
      },
      cancel(){
        this.$router.push('/confirmPishonLevelPayment');
      }
    },
    created() {

    }
  }
</script>