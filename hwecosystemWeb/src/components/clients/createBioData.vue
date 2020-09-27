<template>
    <div>
        

            <div class="q-pa-md">
                <q-card class="column full-height" style="width: 500px">
          
          <q-card-section class="bg-primary text-white">
            <div class="text-h6">Bio Data</div>
          </q-card-section>

          <q-card-section>
              <div class="row">
                    <!-- <q-uploader
                    url="http://localhost:52766/api/Clients/UploadPhoto"
                    extensions=".gif,.jpg,.jpeg,.png"
                    @add="file_selected"
                    />

                    <q-btn  label="Upload" color="primary"  @click="uploadFile" size=md no-caps></q-btn> -->

                    <!-- <q-uploader
                        label="Upload Picture"
                        :factory="factoryFn"
                        style="max-width: 300px"
                    /> -->

                    <q-uploader
                    label="Auto Uploader"
                      auto-upload
                      :url="getUrl"
                      multiple
                      />
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <div class="col-5">
                        <q-input v-model="bloodGroup" label="Blood Group"></q-input>
                    </div>

                    <div class="col-2"></div>  

                    <div class="col-5">
                        <q-input v-model="genotype" label="Genotype"></q-input>
                    </div>     
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <!-- <div class="col-5">
                        <q-input v-model="maritalStatus" label="MaritalStatus"></q-input>
                    </div>

                    <div class="col-2"></div>  -->

                    <div class="col-12">
                      <q-select 
                            color="grey-3" 
                            outlined label-color="primary"
                            v-model="lGAOfOrigin"
                            :options ="AuthDTO.LGAs"
                            label="LGA of Origin">
                        </q-select>
                    </div>     
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <div class="col-12">
                      <q-select 
                            color="grey-3" 
                            outlined label-color="primary"
                            v-model="stateOfOrigin"
                            :options ="AuthDTO.States"
                            label="State of Origin">
                        </q-select>
                    </div> 

                     <!-- <div class="col-2"></div>  

                    <div class="col-5">
                        <q-input v-model="country" label="Country"></q-input>
                    </div>   --> 
  
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
import { $http } from 'boot/axios' 
export default {
    computed: {
      AuthDTO(){
        return this.$store.getters['authenticationStore/AuthDTO'];
      },
        PersonalDataDTO() {
            return this.$store.getters['clientStore/PersonalDataDTO'];
        },
        base64String(){
            return this.$store.getters['clientStore/base64String'];
        }
      },
      components: {
          
        },
      data () {
    return {
            bloodGroup:"",
            genotype:"",
            maritalStatus:"",
            lGAOfOrigin:"",
            stateOfOrigin:"",
            country:"",
            selected_file:'',
            check_if_document_upload:false
            }
        },
      methods: {
          getUrl (files) {
          return `http://localhost:52766/api/Clients/UploadPhoto`
        },
          factoryFn (file) {
      return new Promise((resolve, reject) => {
        // Retrieve JWT token from your store.
        //const token = "myToken";
        resolve({
          url: `http://localhost:52766/api/Clients/UploadPhoto`,
          method: 'POST',
          headers: [
            { name: 'Content-Type', value: 'application/json-patch+json'}
          ]
        }).then(response => {
            
          console.log(response.data)            
            resolve(response)
            
        })
      })
    },
    file_selected(file) {
      var context = this;
      context.selected_file = file[0];
      console.log(context.selected_file);
      context.check_if_document_upload = true;
      console.log(context.check_if_document_upload);
    },
    uploadFile(){
      var context = this;
      let fd =  new FormData();
      fd.append("file", context.selected_file);
      $http.post('/Clients/UploadPhoto', fd, {
        headers: {'Content-Type': undefined},
      }).then(function(response){
        if(response.data.ok){
            //do something here
        }
      }.bind(this));

    },
    factoryFn (file) {
      return new Promise((resolve, reject) => {
        // Retrieve JWT token from your store.
        resolve({
          url: "http://localhost:52766/api/Clients/UploadPhoto",
          method: 'POST',
          headers: [
            { name: 'Content-Type', value: 'application/json-patch+json'}
          ]
        }).then(function(response){
        if(response.data.ok){
            //do something here
        }
      }.bind(this));
      })
    },
          update(){
            var context = this;

          this.$store.dispatch('clientStore/UpdateBioData', {
                bloodGroup: context.bloodGroup,
                genotype: context.genotype,
                maritalStatus: context.maritalStatus,
                lGAOfOrigin: context.lGAOfOrigin,
                stateOfOrigin: context.stateOfOrigin,
                country: context.country,
                id: context.PersonalDataDTO.id,
                base64String:context.base64String
                });

               
      },
      cancel(){
        this.$store.commit('clientStore/CancelBioDataDialog');
        this.$store.commit('clientStore/ShowContactDataDialog');
      }
    },
    created() {
       /*  var context = this;
        var bioData = this.$store.setters['clientStore/BioDataDTO']
        context.bloodGroup = bioData.bloodGroup;
        context.genotype = bioData.genotype;
        context.maritalStatus = bioData.maritalStatus;
        context.lGAOfOrigin = bioData.lGAOfOrigin;
        context.stateOfOrigin = bioData.stateOfOrigin;
        context.country = bioData.country; */

  }
}
</script>

<style scoped>

</style>