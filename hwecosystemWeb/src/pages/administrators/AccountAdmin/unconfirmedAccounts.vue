<template>
  <div>
      <div v-show="showSimulatedReturnData">

        <!-- <div class="row text-center flex flex-center q-pb-lg">
           <q-btn 
               color="primary" 
               label="Comfirm Payment" 
               @click="comfirmpayment" 
               size=sm no-caps></q-btn>
      </div> -->

<div class="row text-center flex flex-center q-pb-lg">

<div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
 <div class="q-pa-md" style="font-family: Lato;">
  
  <q-card class="q-pa-sm q-gutter-sm"> 

          <q-card-section class="bg-primary text-white">
            <div class="row">
              <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                <div class="text-subtitle2">Un-comfirmed Accounts</div>
              </div>
            </div>
          </q-card-section>

           <q-card-section>
             <q-table 
             title="Payments" 
             :data="accountDTO.accountModels" 
             :columns="columns" 
             row-key="name" 
             binary-state-sort
             >


      <template v-slot:body="props">
          <q-tr 
          v-if ="!props.row.isPaid"
          :props="props">
            <q-td key="fullName" :props="props">{{ props.row.fullName }}</q-td>
            <q-td key="contibution" :props="props">{{ props.row.contibution }}</q-td>
            <q-td key="registrationFee" :props="props">{{ props.row.registrationFee }}</q-td>
            <q-td key="entryDate" :props="props">{{ props.row.entryDate }}</q-td>
            <q-td key="comfirmPayment" :props="props">

              <q-btn 
               color="primary" 
               label="Comfirm Payment" 
               @click="comfirmpayment(props.row)" 
               size=sm no-caps></q-btn>
            </q-td>
          </q-tr>
        </template>
    </q-table>

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
          IdentityModel(){
            return this.$store.getters['authenticationStore/IdentityModel'];
        },
        accountDTO(){
            return this.$store.getters['accountStore/accountDTO'];
        },
        visible(){
          return this.$store.getters['accountStore/visible'];
        },
        showSimulatedReturnData(){
          return this.$store.getters['accountStore/showSimulatedReturnData'];
        }
      },
        data () {
    return {
            selected: null,
            loading1: false,
            columns: [
              { name: "fullName", label: "FullName", field: "", align: "left" },
              { name: "contibution", label: "Contribution (₦)", field: "", align: "left" },
              { name: "registrationFee", label: "Registration (₦)", field: "", align: "left" },
              { name: "entryDate", label: "Contribution Payment Date", field: "", align: "left" },
              { name: "comfirmPayment", label: "Comfirm Payment", field: "actions", align: "left" }
            ]
            }
        },
        props: {
            theme_color: {
            type: String,
            default: 'rgb(0, 163, 82)'
            }
        },
        methods: {
          comfirmpayment(tableRow){
              this.$store.commit('accountStore/SetSelectedAccount', tableRow)
          }

        },
        created() {
        this.$store.dispatch('accountStore/GetUnComfirmedAccounts')

      }
    }
</script>
