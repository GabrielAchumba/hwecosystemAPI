<template>
    <paystack
        style="background-color:green; width:120px;height:40px;color:white;border-radius:5px;text-transform:lowercase;"
        :amount="amount"
        :email="email"
        :paystackkey="paystackkey"
        :reference="reference"
        :callback="callback"
        :close="close"
        :embed="false"
    >
       <i class="fas fa-money-bill-alt"></i>
       MAKE PAYMENT
    </paystack>
</template>

<script type="text/javascript">
import paystack from 'vue-paystack';
export default {
    components: {
        paystack  
    },
    props: {
  	 amount: {
      type: Number
    },
    paystackkey: {
      type: String
    }
  },
    data(){
        return{
          email: "achumba.gabriel2017@gmail.com" // Customer email
          //amount: 0
        }
    },
    computed: {
      reference(){
        let text = "";
        let possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        for( let i=0; i < 10; i++ )
          text += possible.charAt(Math.floor(Math.random() * possible.length));

        return text;
      }
    },
    methods: {
      callback: function(response){
        console.log(response)

         if(response.status == "success"){
           console.log("Payment successful")
           this.$store.commit('accountStore/GetPaymentResponse', response);
          this.$store.commit('accountStore/UpdateIsPaymentSuccessful', true);
          
        } 
        else{
          console.log("Payment failed")
          this.$store.commit('accountStore/UpdateIsPaymentSuccessful', false)
        }
      
      },
      close: function(){
          console.log("Payment closed")
      }
    },
  created() {

  }
}
</script>