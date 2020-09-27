<template>
    <div>
        

            <div class="q-pa-md">
                <q-card class="column full-height" style="width: 500px">
          
          <q-card-section class="bg-primary text-white">
            <div class="text-h6">Update Cut Off Score</div>
          </q-card-section>

          <q-card-section>

                <div class="row">

                    <div class="col-12">
                      <q-select 
                            color="grey-3" 
                            outlined label-color="primary"
                            v-model="subject"
                            :options ="AuthDTO.PrimarySubjects"
                            label="Primary School Subject">
                        </q-select>
                    </div>     
                </div>

                 <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <div class="col-5">
                        <q-input v-model="score" label="Score (%)"></q-input>
                    </div>

                </div>

          </q-card-section>
          
          <q-card-actions align="right">
            <q-btn  label="Update" color="primary"  @click="update" size=md no-caps></q-btn>
            <q-btn  label="Cancel" color="primary"  @click="cancel" size=md no-caps></q-btn>

          </q-card-actions>
        </q-card>
                
            </div>
        
    </div>
</template>

<script>
export default {
    computed: {
      AuthDTO(){
        return this.$store.getters['authenticationStore/AuthDTO'];
      },
      SelectedPrimaryCutOff(){
          return this.$store.getters['administratorStore/SelectedPrimaryCutOff'];
      }
    },
      components: {
          
        },
      data () {
    return {
            subject:"",
            score:""
            }
        },
      methods: {
          update(){
            var context = this;

          this.$store.dispatch('administratorStore/UpdatePrimaryOptionCutOff', {
                subject: context.subject,
                score: context.score,
                id: context.SelectedPrimaryCutOff.id
                });

               
      },
      cancel(){
        this.$store.commit('administratorStore/HidePrimaryOptionCutOffUDialog');
      }
    },
    created(){
      var context = this;
        var primarycutoff = this.$store.getters['administratorStore/SelectedPrimaryCutOff'];
        context.subject=primarycutoff.subject;
        context.score=primarycutoff.score;
    }
}
</script>

<style scoped>

</style>