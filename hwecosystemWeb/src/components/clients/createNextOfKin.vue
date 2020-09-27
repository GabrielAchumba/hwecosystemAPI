<template>
    <div>
        

            <div class="q-pa-md">
                <q-card class="column full-height" style="width: 500px">
          
          <q-card-section class="bg-primary text-white">
            <div class="text-h6">Next of Kin Data</div>
          </q-card-section>

          <q-card-section>

                <div class="row">
                    <div class="col-12">
                        <q-input v-model="nOKNames" label="Full Name"></q-input>
                    </div>     
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <div class="col-5">
                        <q-input v-model="nOKPhoneNumber" label="Phone Number"></q-input>
                    </div>

                    <div class="col-2"></div>  

                    <div class="col-5">
                        <q-input v-model="nOKRelationship" label="Relationship"></q-input>
                    </div>     
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <div class="col-12">
                         <q-input
                            v-model="nOKAddress"
                            filled
                            clearable
                            type="textarea"
                            color="blue"
                            label="Address"
                        />
                    </div>   
  
                </div>

          </q-card-section>
          
          <q-card-actions align="right">
            <q-btn  label="Next" color="primary"  @click="update" size=md no-caps></q-btn>
            <q-btn  label="Cancel" color="primary"  @click="cancel" size=md no-caps></q-btn>

          </q-card-actions>
        </q-card>
                
            </div>


       <!--  <div class="row">
            <div class="col-12" height="10"></div>   
        </div>  -->
        
    </div>
</template>

<script>

export default {
    computed: {
        PersonalDataDTO() {
            return this.$store.getters['clientStore/PersonalDataDTO'];
        }
      },
      components: {
          
        },
      data () {
    return {
            nOKNames:"",
            nOKAddress:"",
            nOKPhoneNumber:"",
            nOKRelationship:""
            }
        },
      methods: {
          
          update(){
            var context = this;

          this.$store.dispatch('clientStore/UpdateNextOfKinDTO', {
                nOKNames: context.nOKNames,
                nOKAddress: context.nOKAddress,
                nOKPhoneNumber: context.nOKPhoneNumber,
                nOKRelationship: context.nOKRelationship,
                id: context.PersonalDataDTO.id
                });

               
      },
      cancel(){
        this.$store.commit('clientStore/CancelNextOfKinDataDialog');
        this.$store.commit('clientStore/ShowBioDataDialog');
      }
    },
    created() {
        

  }
}
</script>

<style scoped>

</style>