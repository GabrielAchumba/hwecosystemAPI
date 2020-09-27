<template>
  <div>
    <div v-show="showSimulatedReturnData">

      <div class="row text-center flex flex-center q-pb-lg">
        <div class="text-h6 text-green-8 text-weight-bolder q-mt-sm">Contributor's Full Name:</div>
        <br>
        <div class="text-h6 text-weight-bolder q-mt-sm"> {{SelectedAccount.fullName}}</div>
      </div>

    <div class="row bg-white q-mt-sm">
      <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
        <div class="q-pa-md">
         <q-img 
            :src=SelectedAccount.base64String
            spinner-color="white"
            class="rounded-borders"/>

        </div>
      </div>
      <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12">
        <div class="row">
          <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" :class="$q.platform.is.desktop ? '' : 'q-px-md'">

            <div>
              <div class="text-caption text-green-8 text-weight-bolder q-mt-sm">Registration Fee</div>
              <span class="text-h6">₦2,000.00</span>
            </div>

            <div>
              <div class="text-caption text-green-8 text-weight-bolder q-mt-sm">Contribution</div>
              <span class="text-h6">₦10,000.00</span>
            </div>

            <div>
              <div class="text-caption text-green-8 text-weight-bolder q-mt-sm">Total Amount</div>
              <span class="text-h6">₦12,000.00</span>
            </div>

            <div class="q-mt-md">
              <q-btn class="q-mt-md" color="orange-9" @click="comfirmpayment" icon="shopping_cart" label="Comfirm"/>
              <q-btn class="q-mt-md q-ml-md" color="orange-8" @click="cancel" icon="cancel_presentation" label="Cancel"/>
            </div>
          </div>
        </div>

        <!--</q-scroll-area>-->
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

        IdentityModel(){
            return this.$store.getters['authenticationStore/IdentityModel'];
        },
        SelectedAccount(){
            return this.$store.getters['accountStore/SelectedAccount'];
        },
        visible(){
          return this.$store.getters['accountStore/visible'];
        },
        showSimulatedReturnData(){
          return this.$store.getters['accountStore/showSimulatedReturnData'];
        }
      },
    data() {
      return {
        slide: 1,
        tab: 'Specifications',
        dense: true,
        cost: 0,
        readonly: true,
        readonlyUnits: true,
        base64String: "",
        deliverBy: ""
      }
    },
    methods: {
        comfirmpayment(){
        confirm("I hope you have checked all needed to be checked?" + "\n" + 
        "Once you click 'Ok', you cannot undo it") &&
          this.comfirmpaymentPrivate()
      },
      comfirmpaymentPrivate(){
        this.$store.dispatch('accountStore/ComfirmPayment')
      },
      cancel(){
        this.$router.push('/confirmEntryPayment');
      }
    },
    created() {

    }
  }
</script>

<style scoped>

</style>
