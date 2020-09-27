<template>
  <div>
      <div style="background-color: #000000ad !important;">

<div class="row text-center flex flex-center q-pb-lg">

<div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
 <div class="q-pa-md" style="font-family: Lato;">
  
  <q-card class="q-pa-sm q-gutter-sm"> 

          <q-card-section class="bg-primary text-white">
            <div class="row">
              <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                <div class="text-subtitle2">Contributors Not Paid</div>
              </div>
            </div>
          </q-card-section>

           <q-card-section>
             <q-table 
             title="Unpaid Contributors" 
             :data="levelDTO.levelModels" 
             :columns="columns" 
             row-key="name" 
             binary-state-sort
             >


      <template v-slot:body="props">
          <q-tr 
          v-if ="!props.row.isPaid"
          :props="props">
            <q-td key="contributorFullName" :props="props">{{ props.row.contributorFullName }}</q-td>
            <q-td key="contributorUserName" :props="props">{{ props.row.contributorUserName }}</q-td>
            <q-td key="paymentReceived" :props="props">{{ props.row.paymentReceived }}</q-td>
            <q-td key="payContributor" :props="props">

             <q-btn 
              icon="update"
              color="primary" 
              no-shadows
              @click="payingContributor(props.row)" 
              size=sm no-caps>
              <q-tooltip>
                Update Payment
              </q-tooltip>
              </q-btn>
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
  </div>
</template>

<script>

    export default {
        computed: {
          IdentityModel(){
            return this.$store.getters['authenticationStore/IdentityModel'];
        },
        levelDTO(){
            return this.$store.getters['accountStore/levelDTO'];
        }
      },
        data () {
    return {
            selected: null,
            loading1: false,
            columns: [
              { name: "contributorFullName", label: "Full Name", field: "", align: "left" },
              { name: "contributorUserName", label: "UserName", field: "", align: "left" },
              { name: "paymentReceived", label: "Level Entitlement (₦)", field: "", align: "left" },
              { name: "payContributor", label: "Pay Entitlement", field: "actions", align: "left" }
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
          comfirmpayment(row){
              this.$store.commit('accountStore/SetSelectedAccount', row)
          }

        },
        created() {
        this.$store.dispatch('accountStore/GetLevelsByIndex')

      }
    }
</script>
