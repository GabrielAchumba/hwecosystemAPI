<template>
    <div>
        

            <div class="q-pa-md">
                <q-card class="column full-height" style="width: 500px">
          
          <q-card-section class="bg-primary text-white">
            <div class="text-h6">Contact Data</div>
          </q-card-section>

          <q-card-section>
                <div class="row">
                    <div class="col-5">
                        <q-input v-model="phoneNumber" label="Phone Number"></q-input>
                    </div>

                    <div class="col-2"></div>  

                    <div class="col-5">
                        <q-input v-model="email" label="Email"></q-input>
                    </div>     
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <div class="col-5">
                        <q-input v-model="residentialCity" label="Residential City"></q-input>
                    </div>

                    <div class="col-2"></div>  

                    <div class="col-5">
                        <q-select 
                            color="grey-3" 
                            outlined label-color="primary"
                            v-model="residentialState"
                            :options ="AuthDTO.States"
                            label="Residential State">
                        </q-select>
                    </div>     
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <div class="col-12">
                         <q-input
                            v-model="address"
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
        AuthDTO(){
        return this.$store.getters['authenticationStore/AuthDTO'];
      },
        PersonalDataDTO() {
            return this.$store.getters['clientStore/PersonalDataDTO'];
        }
      },
      components: {
          
        },
      data () {
    return {
            phoneNumber:"",
            email:"",
            address:"",
            residentialCity:"",
            residentialState:""
            }
        },
      methods: {
          update(){
            var context = this;

          this.$store.dispatch('clientStore/UpdateContactDTO', {
                phoneNumber: context.phoneNumber,
                email: context.email,
                address: context.address,
                residentialCity: context.residentialCity,
                residentialState: context.residentialState,
                id: context.PersonalDataDTO.id
                });

               
      },
      cancel(){
        this.$store.commit('clientStore/CancelContactDataDialog');
        this.$store.commit('clientStore/ShowPersonalDataDialog');
      }
    },
    created() {
        

  }
}
</script>

<style scoped>

</style>