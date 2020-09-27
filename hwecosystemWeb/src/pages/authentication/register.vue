<template>
  <div>
    <div v-show="showSimulatedReturnData">
  <div class="q-pa-md">
    <q-stepper
      v-model="step"
      vertical
      color="primary"
      animated
    >
      <q-step
        :name="1"
        title="Personal Data"
        icon="settings"
        :done="step > 1"
      >
        <personalData-app></personalData-app>

        <q-stepper-navigation>
          <q-btn @click="updatestep(1)" color="primary" label="Next" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="2"
        title="Contact Data"
        icon="create_new_folder"
        :done="step > 2"
      >
        <contactData-app></contactData-app>

        <q-stepper-navigation>
          <q-btn @click="updatestep(2)" color="primary" label="Next" />
          <q-btn flat @click="backstep(1)" color="primary" label="Back" class="q-ml-sm" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="3"
        title="Next of Kin Data"
        icon="create_new_folder"
        :done="step > 3"
      >
        <nextOfKinData-app></nextOfKinData-app>

        <q-stepper-navigation>
          <q-btn @click="updatestep(3)" color="primary" label="Next" />
          <q-btn flat @click="backstep(2)" color="primary" label="Back" class="q-ml-sm" />
        </q-stepper-navigation>
      </q-step>

      <q-step
        :name="4"
        title="Back Account Data"
        icon="add_comment"
      >
        <bankAccountData-app></bankAccountData-app>

        <q-stepper-navigation>
          <q-btn color="primary" label="Finish" @click="updatestep(4)"/>
          <q-btn flat @click="backstep(3)" color="primary" label="Back" class="q-ml-sm" />
        </q-stepper-navigation>
      </q-step>
    </q-stepper>
  </div>
  </div>
  <q-inner-loading :showing="visible">
        <q-spinner-gears size="50px" color="primary" />
      </q-inner-loading>
  </div>
</template>

<script>
import personalData from 'pages/authentication/personalData.vue'
import bioData from 'pages/authentication/bioData.vue'
import contactData from 'pages/authentication/contactData.vue'
import nextOfKinData from 'pages/authentication/nextOfKinData.vue'
import bankAccountData from 'pages/authentication/bankAccountData.vue'

export default {
   computed: {
        step() {
            return this.$store.getters['clientStore/step'];
        },
        visible(){
          return this.$store.getters['clientStore/visible'];
        },
        showSimulatedReturnData(){
          return this.$store.getters['clientStore/showSimulatedReturnData'];
        },
        PersonalDataDTO(){
          return this.$store.getters['clientStore/PersonalDataDTO'];
        },
        ContactDTO(){
          return this.$store.getters['clientStore/ContactDTO'];
        },
        NextOfKinDTO(){
          return this.$store.getters['clientStore/NextOfKinDTO'];
        },
        BankAccountDTO(){
          return this.$store.getters['clientStore/BankAccountDTO'];
        },
        tab(){
              return this.$store.getters['clientStore/tab'];
        }
      },
    components: {
            'personalData-app': personalData,
            'bioData-app': bioData,
            'contactData-app': contactData,
            'nextOfKinData-app': nextOfKinData,
            'bankAccountData-app': bankAccountData
        },
  data () {
    return {

    }
  },
  methods: {
    backstep (previousstepvalue){
      this.$store.commit('clientStore/backstep', previousstepvalue)

    },
    updatestep(previousstepvalue){
      var context = this;

      if(previousstepvalue == 1){
        if (context.PersonalDataDTO.firstName === "") {
          alert("Enter First Name");
          return;
        }
        if (context.PersonalDataDTO.lastName === "") {
          alert("Enter Last Name");
          return;
        }
        if (context.PersonalDataDTO.gender === "") {
          alert("Enter Gender");
          return;
        }
        if (context.PersonalDataDTO.userName === "") {
          alert("Enter UserName");
          return;
        }
        if (context.PersonalDataDTO.password === "") {
          alert("Enter Password");
          return;
        }

        if (context.PersonalDataDTO.parentUserName === "") {
          alert("Enter Parent UserName");
          return;
        }
        this.$store.dispatch('clientStore/CreatePersonalDataDTO', previousstepvalue)
      }

      if(previousstepvalue == 2){
        if (context.ContactDTO.phoneNumber === "") {
          alert("Enter your phone number without +234");
          return;
        }

        if (context.ContactDTO.residentialCity === "") {
          alert("Enter your residential city");
          return;
        }

        if (context.ContactDTO.residentialState === "") {
          alert("Enter your residential state");
          return;
        }

        this.$store.dispatch('clientStore/UpdateContactDTO', previousstepvalue)
      }

      if(previousstepvalue == 3){

         if (context.NextOfKinDTO.nOKNames === "") {
          alert("Enter next of kin full name");
          return;
        }
         if (context.NextOfKinDTO.nOKPhoneNumber === "") {
          alert("Enter next of kin phone number without +234");
          return;
        }

         if (context.NextOfKinDTO.nOKRelationship === "") {
          alert("Enter next of kin relationship");
          return;
        }
        this.$store.dispatch('clientStore/UpdateNextOfKinDTO', previousstepvalue)

      }

      if(previousstepvalue == 4){

         if (context.BankAccountDTO.bankName === "") {
          alert("Enter your bank name");
          return;
        }

         if (context.BankAccountDTO.accountName === "") {
          alert("Enter your account name");
          return;
        }

         if (context.BankAccountDTO.accountNumber === "") {
          alert("Enter your account number");
          return;
        }
        this.$store.dispatch('clientStore/UpdateBankAccountData')
      }
      
    }
  }
}
</script>