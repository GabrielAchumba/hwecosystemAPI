<template>
  
  <div id="q-app">
  <div class="q-pa-sm q-gutter-sm">
    
    <div class="row">
          <div class="col-12" style="height:5px">     
          </div>  
    </div>

    <div class="row">
            <q-btn 
               color="primary" 
               label="Create CutOff" 
               @click="ShowPrimaryOptionCutOffCDialog" 
               size=sm no-caps></q-btn>
      </div>
      
      <div class="row">
          <div class="col-12" style="height:5px">     
          </div>  
    </div>
    
    <div class="row"> 
      <div class="col-12">     

        <q-card>
          <q-card-section class="bg-primary text-white">
            Cut off Score
          </q-card-section>
           <q-card-section>
               <q-table  
             :data="PrimaryCutOffs" 
             :columns="columns" 
             row-key="name" 
             binary-state-sort
             style="height:250px">


      <template v-slot:body="props">
          <q-tr :props="props">
            <q-td key="subject" :props="props">{{ props.row.subject }}</q-td>
            <q-td key="score" :props="props">{{ props.row.score }}</q-td>
           <q-td key="actions" :props="props">
             <q-btn 
              icon="update"
              color="primary" 
              no-shadows
              @click="ShowPrimaryOptionCutOffUDialog(props.row)" 
              size=sm no-caps>
              <q-tooltip>
                Update CutOff
              </q-tooltip>
              </q-btn>

              <q-btn 
              icon="delete"
              color="primary" 
              no-shadows
              @click="DeletePrimaryOptionCutOff(props.row)" 
              size=sm no-caps>
              <q-tooltip>
                Delete CutOff
              </q-tooltip>
              </q-btn>
            </q-td>
          </q-tr>
        </template>
    </q-table>

    <div class="row">
          <div class="col-12" style="height:10px">     
          </div>  
    </div>

    <div class="row">
            <q-btn 
               color="primary" 
               label="Ok" 
               @click="OkAction" 
               size=sm no-caps></q-btn>
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
    PrimaryCutOffs() {
            return this.$store.getters['administratorStore/PrimaryCutOffs'];
        }
  },
  components: {
  },
  data() {
    return {
       columns: [
        { name: "subject", label: "Subject", field: "", align: "left" },
        { name: "score", label: "Score (%)", field: "", align: "left" },
        {
          name: "actions",
          label: "Actions",
          field: "actions",
          style: "width: 50px"
        }
       ]
    };
  },
 methods: {
    DeletePrimaryOptionCutOff(selectedItem){
      var context = this;
      confirm("Are you sure you want to delete this item?") &&
        this.deleteItemPrivate(selectedItem);
    },
    deleteItemPrivate(selectedItem){
      this.$store.dispatch('administratorStore/DeletePrimaryOptionCutOff', selectedItem)
    },
    ShowPrimaryOptionCutOffCDialog(){
      this.$store.commit('administratorStore/ShowPrimaryOptionCutOffCDialog')
    },
    ShowPrimaryOptionCutOffUDialog(selectedItem){
       this.$store.commit('administratorStore/ShowPrimaryOptionCutOffUDialog', selectedItem)
    },
    OkAction(){

    }

  },
  created() {
    this.$store.dispatch('administratorStore/ReadPrimaryOptionCutOff')

  }
  
}
</script>

<style scoped>

</style>
