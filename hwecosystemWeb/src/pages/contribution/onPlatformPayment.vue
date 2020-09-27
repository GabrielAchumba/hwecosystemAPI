<template>
<div>

<div class="row text-center flex flex-center q-pb-lg">

<div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
 <div class="q-pa-md" style="font-family: Lato;">
  
  <q-card class="q-pa-sm q-gutter-sm"> 

            <q-card-section class="bg-primary text-white">
            <div class="row text-center flex flex-center q-pb-lg">
              <div class="col-md-3 col-lg-3 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
              </div>
               <div class="col-md-6 col-lg-6 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                 <p>On-Platform Payment</p>
               </div>
                
                <div class="col-md-3 col-lg-3 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                </div>
                
            </div>

          </q-card-section>

          <q-card-section>
            <div class="row text-center flex flex-center q-pb-lg">

               <div class="col-md-5 col-lg-5 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">           
                 <div>
                  <div class="text-caption text-green-8 text-weight-bolder q-mt-sm">Registration</div>
                  <span class="text-h6">₦2,000.00</span>
                  <br>
                  <br>
                </div>

                <div>
                  <div class="text-caption text-green-8 text-weight-bolder q-mt-sm">Contribution</div>
                  <span class="text-h6">₦10,000.00</span>
                  <br>
                  <br>
                </div>
               </div>
                
                <div class="col-md-2 col-lg-2 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                </div>

                
              <div 
              v-if="DoesNotHaveMoneyAccount"
              class="col-md-5 col-lg-5 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                  <br>
                  <br>
                  <div
                    v-if="HasNotPaid">
                   <payStackButton-app
                    :amount="TotalCost"
                    :paystackkey="paystackkey">
                    </payStackButton-app>
                  </div>

              </div>

            </div>

          </q-card-section>

      </q-card>
      
  </div>
</div>

</div>

  </div>
</template>

<script>
import payStackButton from 'pages/contribution/payStackButton.vue';
  export default {
      computed: {
        IdentityModel(){
            return this.$store.getters['authenticationStore/IdentityModel'];
        },
        DoesNotHaveMoneyAccount(){
          return this.$store.getters['authenticationStore/DoesNotHaveMoneyAccount'];
        },
        HasNotPaid(){
          return this.$store.getters['accountStore/HasNotPaid'];
        }
      },
       components: {
            'payStackButton-app' : payStackButton
        },
    data() {
      return {
        TotalCost: 1200000

      }
    },
    methods: {

    },
    created() {
        var context = this;
        context.paystackkey = this.$store.getters['authenticationStore/paystackkey'];
    }
  }
</script>