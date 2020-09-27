<template>
  <div>
      <div>

<div class="row text-center flex flex-center q-pb-lg">

<div class="col-md-4 col-lg-4 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
   <!--  <div>
      <div class="q-gutter-sm">
        <q-btn size="sm" color="primary" @click="selectGoodService" label="Select 'Good service'" />
        <q-btn v-if="selected" size="sm" color="red" @click="unselectNode" label="Unselect node" />
      </div>
    </div> -->
    <q-tree
      :nodes="Cycles"
      default-expand-all
      node-key="id"
      @update:selected="selectNode"
      :selected="selected"
      default-expand-all
    />
</div>

<div class="col-md-8 col-lg-8 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
 <div class="q-pa-md" style="font-family: Lato;">
  
  <q-card class="q-pa-sm q-gutter-sm"> 

          <q-card-section class="bg-primary text-white">
            <div class="row">
              <div class="col-4">
                <div class="text-subtitle2">Level Name: {{ DescendantDTO.levelName }}</div>
              </div>
               <div class="col-4"></div>
                <div class="col-4">Total Amount Paid: ₦{{ DescendantDTO.totalPayment }}</div>
            </div>

            <div class="row">
              <div class="col-4">
                <div class="text-subtitle2">Children: {{ DescendantDTO.nChildren }}</div>
              </div>
               <div class="col-4"></div>
                <div class="col-4">GrandChildren: {{ DescendantDTO.nGrandChildren }}</div>
            </div>

            <div class="row">
              <div class="col-4">
                <div class="text-subtitle2">Level Completed: {{ DescendantDTO.isLevelCompleted }}</div>
              </div>
               <div class="col-4"></div>
                <div class="col-4">Level Entitlement Paid: {{ DescendantDTO.isLevelEntitlementPaid }}</div>
            </div>
          </q-card-section>

           <q-card-section>
             <q-table 
             title="Descendants" 
             :data="DescendantDTO.levelModels" 
             :columns="columns" 
             row-key="name" 
             binary-state-sort
             >


      <template v-slot:body="props">
          <q-tr 
          v-if ="!props.row.isPaid"
          :props="props">
            <!-- <q-td key="image" :props="props">{{ props.row.image }}</q-td> -->
            <q-td key="contributorFullName" :props="props">{{ props.row.contributorFullName }}</q-td>
            <q-td key="paymentReceived" :props="props">{{ props.row.paymentReceived }}</q-td>
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
        Cycles(){
            return this.$store.getters['dashboardStore/Cycles'];
        },
        DescendantDTO(){
            return this.$store.getters['dashboardStore/DescendantDTO'];
        }
      },
        data () {
    return {
            selected: null,
            loading1: false,
            columns: [
              { name: "contributorFullName", label: "Full Name", field: "", align: "left" },
              { name: "paymentReceived", label: "Amount Paid (₦)", field: "", align: "left" }
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
          selectNode (v) {
            var context = this;

            if(v !== null){
              context.selected = v;
              console.log(context.selected)
              this.$store.dispatch('dashboardStore/GetDesendantsPerLevel', {
                id: context.selected,
                contributorId: context.IdentityModel.id
              })
            }
            return;
          }
        },
        created() {
        var context =this;
        this.$store.dispatch('dashboardStore/GetCyclesWithLevelsByUserId')

      }
    }
</script>
