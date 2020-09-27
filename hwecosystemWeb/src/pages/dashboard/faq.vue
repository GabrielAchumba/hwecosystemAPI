<template>
  <div>
      <div>

<div class="row text-center flex flex-center q-pb-lg">

<div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
 <div class="q-pa-md" style="font-family: Lato;">
  
  <q-card class="q-pa-sm q-gutter-sm"> 

          <q-card-section class="bg-primary text-white">
            <div class="row">
              <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                <div class="text-subtitle2">Frequently Asked Questions</div>
              </div>
            </div>
          </q-card-section>

           <q-card-section>
             <q-table 
             title="Relevant Information" 
             :data="fAQs" 
             :columns="columns" 
             row-key="name" 
             binary-state-sort
             >


      <template v-slot:body="props">
          <q-tr 
          v-if ="!props.row.isPaid"
          :props="props">
            <q-td key="question" :props="props">{{ props.row.question }}</q-td>
            <q-td key="answer" :props="props">{{ props.row.answer }}</q-td>
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
        fAQs(){
            return this.$store.getters['dashboardStore/fAQs'];
        }
      },
    data() {
      return {
        columns: [
              { name: "question", label: "Question", field: "", align: "left" },
              { name: "answer", label: "Answer", field: "", align: "left" }
            ]
      }
    },
    methods: {
      
    },
    created() {

    }
  }
</script>

<style scoped>

</style>
