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

                
              <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">

                  <span class="text-h6">Account Name: Portharcourt Health and Wealth Cooperative Investment and Credit Society Limited</span>
                  <br>
                  <span class="text-h6">Bank Name: FCMB</span>
                  <br>
                  <span class="text-h6">Account Number: 3002659051</span>
                  <br>
                  <br>
                  
              </div>

            </div>

          </q-card-section>


          <q-card-section>
            <div class="row text-center flex flex-center q-pb-lg">

               <div class="col-md-5 col-lg-5 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">           
                 <div>
                  <div class="text-caption text-green-8 text-weight-bolder q-mt-sm">Registration</div>
                  <span class="text-h6">₦2,000.00</span>
                </div>

                <div>
                  <div class="text-caption text-green-8 text-weight-bolder q-mt-sm">Contribution</div>
                  <span class="text-h6">₦10,000.00</span>
                </div>
               </div>
                
                <div class="col-md-2 col-lg-2 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                </div>

                
              <div 
              v-if=DoesNotHaveMoneyAccount
              class="col-md-5 col-lg-5 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">

                  <input 
                  v-if=HasNotPaid
                  type="file" @change="onFileSelected"/>

                  <br>
                  <br>
                  <q-btn 
                  v-if=HasNotPaid
                  class="text-capitalize" 
                            exact
                            size="sm" style="width:75px" dense label="Upload Paycheck"
                                type="button"
                                    color="primary"
                                    @click="onUpload" />

                    <q-btn 
                    v-if=HasNotPaid
                    class="text-capitalize" 
                            exact
                            size="sm" style="width:75px" dense label="Click to Complete Payment"
                                type="button"
                                    color="primary"
                                    @click="OffPlatformPayment" />
                    <br>
                    <br>
                    <p v-if=HasMoneyAccount2>Upload Progress: {{ UploadProgress }} </p>
                    <br>
                    <br>
                    <p 
                    v-if=HasNotPaid
                    color="yellow">{{ responseMessage }} </p>
                    <br>
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
  export default {
      computed: {
          UploadProgress(){
          return this.$store.getters['clientStore/UploadProgress'];
        },
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
    data() {
      return {
        SelectedFile: null,


      }
    },
    methods: {
      onFileSelected(event){
            var context = this;
            context.SelectedFile = event.target.files[0];
            console.log(context.SelectedFile);
            },
      onUpload(){
              var context = this;
                  const fd = new FormData();
                  fd.append('image', context.SelectedFile, context.SelectedFile.name);
                  this.$store.dispatch('accountStore/UploadPhoto', fd); 
      },
      pay(){
        this.$store.dispatch('accountStore/Payment')
      },
      OffPlatformPayment(){
          var context = this;
        this.$store.dispatch('accountStore/OffPlatformPayment', context.IdentityModel.id)
      }
    },
    created() {

    }
  }
</script>