<template>
  <div>
      <div v-show="showSimulatedReturnData">

<div class="row text-center flex flex-center q-pb-lg">

<div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
 <div class="q-pa-md" style="font-family: Lato;">
  
  <q-card class="q-pa-sm q-gutter-sm"> 

          <q-card-section class="bg-primary text-white">
            <div class="row">
              <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                <div class="text-subtitle2">Contributors</div>
              </div>
            </div>
          </q-card-section>

           <q-card-section>
             <q-table 
             title="Contributors" 
             :data="refugeCentersDTO.refugeCenterModels" 
             :columns="columns" 
             row-key="name" 
             binary-state-sort
             >


      <template v-slot:body="props">
          <q-tr
          :props="props">
            <q-td 
            key="fullName" :props="props">{{ props.row.fullName }}</q-td>

            <q-td 
            key="nChildren" :props="props">{{ props.row.nChildren }}</q-td>

            <q-td
            key="nGrandChildren" :props="props">{{ props.row.nGrandChildren }}</q-td>
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
        refugeCentersDTO(){
            return this.$store.getters['administratorStore/refugeCentersDTO'];
        },
         visible(){
          return this.$store.getters['administratorStore/visible'];
        },
        showSimulatedReturnData(){
          return this.$store.getters['administratorStore/showSimulatedReturnData'];
        }
      },
        data () {
    return {
            selected: null,
            loading1: false,
            columns: [
              { name: "fullName", label: "Full Name", field: "", align: "left" },
              { name: "nChildren", label: "Children", field: "", align: "left" },
              { name: "nGrandChildren", label: "GrandChildren", field: "", align: "left" }
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
        this.$store.dispatch('administratorStore/MoveRefugeeToPishon')

      }
    }
</script>

<style>

</style>
