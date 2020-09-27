<template>
    <div>
        

            <div class="q-pa-md">
                <q-card class="column full-height" style="width: 500px">
          
          <q-card-section class="bg-primary text-white">
            <div class="text-h6">Personal Data</div>
          </q-card-section>

          <q-card-section>
              <div class="row">
                    <div class="col-5">
                        <q-input v-model="userName" label="UserName"></q-input>
                    </div>

                    <div class="col-2"></div>  

                    <div class="col-5">
                        <q-input v-model="password" label="Password"></q-input>
                    </div>     
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>
                <div class="row">
                    <div class="col-5">
                        <q-input v-model="title" label="Title"></q-input>
                    </div>

                    <div class="col-2"></div>  

                    <div class="col-5">
                        <q-input v-model="firstName" label="First Name"></q-input>
                    </div>     
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <div class="col-5">
                        <q-input v-model="middleName" label="Middle Name"></q-input>
                    </div>

                    <div class="col-2"></div>  

                    <div class="col-5">
                        <q-input v-model="lastName" label="Last Name"></q-input>
                    </div>     
                </div>

                <div class="row">
                    <div class="col-12" style="height:10px">     
                    </div>  
                </div>

                <div class="row">
                    <div class="col-5">
                        <q-select 
                            color="grey-3" 
                            outlined label-color="blue"
                            v-model="gender"
                            :options ="genders"
                            disabled
                            label="Gender">
                        </q-select>
                    </div> 

                    <div class="col-2"></div>  

                    <div class="col-5">
                        <div class="q-mb-sm">
                            <q-badge color="blue">
                                Date of Birth: {{ date }}
                            </q-badge>
                            </div>

                            <q-btn icon="event" round color="primary">
                            <q-popup-proxy @before-show="updateProxy" transition-show="scale" transition-hide="scale">
                                <q-date v-model="proxyDate">
                                <div class="row items-center justify-end q-gutter-sm">
                                    <q-btn label="Cancel" color="primary" flat v-close-popup />
                                    <q-btn label="OK" color="primary" flat @click="save" v-close-popup />
                                </div>
                                </q-date>
                            </q-popup-proxy>
                            </q-btn>
                    </div>   
                </div>

          </q-card-section>
          
          <q-card-actions align="right">
            <q-btn  label="Next" color="primary"  @click="create" size=md no-caps></q-btn>
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
        },
        genders() {
            return this.$store.getters['clientStore/genders'];
        }
      },
      components: {
          
        },
      data () {
    return {
            title:"",
            firstName:"",
            middleName:"",
            lastName:"",
            gender:"",
            userName:"",
            password:"",
            date: '2019/03/01',
            proxyDate: '2019/03/01'
            }
        },
      methods: {
          updateProxy () {
              var context = this;
            context.proxyDate = context.date
            },
        save () {
            var context = this;
            context.date = context.proxyDate
            },
          create(){
            var context = this;
            var res = context.date.split("/");
            var bDay = parseInt(res[2]);
            var bMonth = parseInt(res[1]);
            var bYear = parseInt(res[0]);

            console.log("Day: ", bDay)
            console.log("Month: ", bMonth)
            console.log("Year: ", bYear)

          this.$store.dispatch('clientStore/CreatePersonalDataDTO', {
                title: context.title,
                firstName: context.firstName,
                middleName: context.middleName,
                lastName: context.lastName,
                gender: context.gender,
                firstName: context.firstName,
                birthDay: bDay,
                birthMonth:bMonth,
                birthYear:bYear,
                userName: context.userName,
                password: context.password
                });

               
      },
      cancel(){
        this.$store.commit('clientStore/CancelPersonalDataDialog');
        this.$store.commit('authenticationStore/showLoginDialog');
      }
    },
    created() {
    

  }
}
</script>

<style scoped>

</style>