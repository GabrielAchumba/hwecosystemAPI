<template>
  <div>
      <div style="background-color: #000000ad !important;">

        <div class="row text-center flex flex-center q-pb-lg">
        <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
           <q-btn 
               color="primary" 
               label="Register Contributor" 
               @click="RegisterContributor" 
               size=sm no-caps></q-btn>
            </div>
      </div>

      <div class="row">
          <div class="col-12" style="height:10px">     
          </div>  
    </div>

<div class="row text-center flex flex-center q-pb-lg">

<div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
 <div class="q-pa-md" style="font-family: Lato;">
  
  <q-card class="q-pa-sm q-gutter-sm"> 

          <q-card-section class="bg-primary text-white">
            <div class="row">
              <div class="col-md-12 col-lg-12 col-sx-12 col-sm-12 q-gutter-lg q-px-xl q-pb-none q-ma-none">
                <div class="text-subtitle2">Registered Contributors</div>
              </div>
            </div>
          </q-card-section>

           <q-card-section>
             <q-table 
             title="Contributors" 
             :data="RegisteredContributors" 
             :columns="columns" 
             row-key="name" 
             binary-state-sort
             >


      <template v-slot:body="props">
          <q-tr 
          v-if ="!props.row.isPaid"
          :props="props">
            <q-td key="title" :props="props">{{ props.row.title }}</q-td>
            <q-td key="firstName" :props="props">{{ props.row.firstName }}</q-td>
            <q-td key="middleName" :props="props">{{ props.row.middleName }}</q-td>
            <q-td key="lastName" :props="props">{{ props.row.lastName }}</q-td>
            <q-td key="gender" :props="props">{{ props.row.gender }}</q-td>

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
        RegisteredContributors(){
            return this.$store.getters['clientStore/RegisteredContributors'];
        }
      },
        data () {
    return {
            selected: null,
            loading1: false,
            columns: [
              { name: "title", label: "Title", field: "", align: "left" },
              { name: "firstName", label: "First Name", field: "", align: "left" },
              { name: "middleName", label: "Middle Name", field: "", align: "left" },
              { name: "lastName", label: "Last Name", field: "", align: "left" },
              { name: "gender", label: "Gender", field: "", align: "left" }
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
            RegisterContributor(){
                this.$router.push('/register');
            },
            showSelectedContributor(row){

            }

        },
        created() {
        this.$store.dispatch('clientStore/GetRegisteredContributors')

      }
    }
</script>
