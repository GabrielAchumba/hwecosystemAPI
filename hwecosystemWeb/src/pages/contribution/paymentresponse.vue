<template>
 <div>
     <div class="col-12">
         <q-card class="column full-height" style="width: 500px">
             <q-card-section>
            <div  v-if="IsPaymentSuccessful">
            <p>
                Payment was succesful. Thanks for joining HAWcom Ecosystem Community.
            </p>
            </div>

            <div  v-else>
            <p>
                Payment was not succesful. Please try again later. Thanks for joining HAWcom Ecosystem Community.
            </p>
            </div>
          </q-card-section>
          <q-card-actions align="right">
               <q-btn 
                @click="Done" color="primary" v-close-popup>
                Done
                </q-btn>
          </q-card-actions>
         </q-card>
     </div>
 </div>
</template>

<script>

export default {
  computed: {
    IsPaymentSuccessful(){
      return this.$store.getters['accountStore/IsPaymentSuccessful'];
    },
    IdentityModel(){
            return this.$store.getters['authenticationStore/IdentityModel'];
        }
   },
  data() {
    return {
      
    };
  },
  methods: {
      Done(){
        var context =  this;
        this.$store.dispatch('accountStore/Payment', context.IdentityModel)
          
      }
  }
};
</script>
