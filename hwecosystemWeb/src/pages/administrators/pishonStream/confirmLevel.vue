<template>
  <div>
      <div v-show="showSimulatedReturnData">

<div class="row text-center flex flex-center q-pb-lg">

<div class="col-md-4 col-lg-4 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">

    <q-tree
      :nodes="Cycles"
      default-expand-all
      node-key="label"
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
                <div class="text-subtitle2">Pishon Sorted Members (Please Comfirm Serially)</div>
              </div>
            </div>
          </q-card-section>

           <q-card-section>
             <q-table 
             title="Contributors" 
             :data="pishonDTOs" 
             :columns="columns" 
             row-key="name" 
             binary-state-sort
             >


      <template v-slot:body="props">
          <q-tr
          :props="props">
            <q-td key="fullName" :props="props">{{ props.row.fullName }}</q-td>
            <q-td key="entryDate" :props="props">{{ props.row.entryDate }}</q-td>
            <q-td key="confirmLevel" :props="props">

             <q-btn 
              icon="update"
              color="primary" 
              no-shadows
              @click="updateLevel(props.row)" 
              size=sm no-caps>
              <q-tooltip>
                Update Level
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
        Cycles(){
            return this.$store.getters['dashboardStore/Cycles'];
        },
        pishonDTOs(){
            return this.$store.getters['administratorStore/PishonDTOs'];
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
              { name: "entryDate", label: "Pishon Entry Date", field: "", align: "left" },
              { name: "confirmLevel", label: "Comfirm Level", field: "actions", align: "left" }
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
          updateLevel(row){
             this.$store.commit('administratorStore/GetSelectedStreamLevel', row);
          },
          selectNode (levelName) {
            var context = this;

            if(levelName !== null){
              context.selected = levelName;
              this.$store.dispatch('administratorStore/FetchPishonDTO', levelName) 

             
            }
            return;
          }
        },
        created() {
        var context =this;
        this.$store.dispatch('dashboardStore/GetPishonLevels')

      }
    }
</script>
