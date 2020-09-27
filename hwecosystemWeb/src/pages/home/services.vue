<template>
  <div>
      <div class="row">
            <div class="col-md-12 col-lg-12 col-xs-12 col-sm-12">
              <h5 class="text-center">Our Streams
                <br>
              </h5>
            </div>
          </div> 
          <div class="q-pa-xl">       
            <div class="row q-col-gutter-sm ">
              <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                <q-item class="box-shadow q-pa-none q-ml-xs ">
                  <q-item-section side :style="'background-color:' + theme_color" class="q-pa-sm q-mr-none text-white">
                    <q-icon name="compare_arrows" size="65px"></q-icon>
                  </q-item-section>
                  <q-item-section class="q-pa-md q-ml-none">
                    <q-item-label class="text-h6 text-grey-9 text-uppercase">PISHON </q-item-label>
                    <q-item-label class="text-grey-8">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</q-item-label>
                  </q-item-section>
                </q-item>
              </div>
              <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                <q-item class="box-shadow q-pa-none q-ml-xs">
                  <q-item-section side :style="'background-color:' + theme_color" class="q-pa-sm q-mr-none text-white">
                    <q-icon name="web" size="65px"></q-icon>
                  </q-item-section>
                  <q-item-section class="q-pa-md q-ml-none">
                    <q-item-label class="text-h6 text-grey-9 text-uppercase">GIHON</q-item-label>
                    <q-item-label class="text-grey-8">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</q-item-label>
                  </q-item-section>
                </q-item>
              </div>
              <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                <q-item class="box-shadow q-pa-none q-ml-xs q-mr-xs">
                  <q-item-section side :style="'background-color:' + theme_color" class="q-pa-sm q-mr-none text-white">
                    <q-icon name="fab fa-wordpress" size="65px"></q-icon>
                  </q-item-section>
                  <q-item-section class="q-pa-md q-ml-none">
                    <q-item-label class="text-h6 text-grey-9 text-uppercase">HIDDEKEL</q-item-label>
                    <q-item-label class="text-grey-8">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</q-item-label>
                  </q-item-section>
                </q-item>
              </div>
            </div>
            <div class="row q-col-gutter-sm q-mt-lg">
              <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                <q-item class="box-shadow q-pa-none q-ml-xs ">
                  <q-item-section side :style="'background-color:' + theme_color" class="q-pa-sm q-mr-none text-white">
                    <q-icon name="settings" size="65px"></q-icon>
                  </q-item-section>
                  <q-item-section class="q-pa-md q-ml-none">
                    <q-item-label class="text-h6 text-grey-9 text-uppercase">EUPHRATES</q-item-label>
                    <q-item-label class="text-grey-8">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</q-item-label>
                  </q-item-section>
                </q-item>
              </div>
              <div class="col-md-4 col-lg-4 col-sm-12 col-xs-12">
                <q-item class="box-shadow q-pa-none q-ml-xs">
                  <q-item-section side :style="'background-color:' + theme_color" class="q-pa-sm q-mr-none text-white">
                    <q-icon name="fas fa-database" size="65px"></q-icon>
                  </q-item-section>
                  <q-item-section class="q-pa-md q-ml-none">
                    <q-item-label class="text-h6 text-grey-9 text-uppercase">SILVER AND GOLD</q-item-label>
                    <q-item-label class="text-grey-8">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</q-item-label>
                  </q-item-section>
                </q-item>
              </div>
            </div>
          </div> 
  </div>
</template>

<script>

    export default {
        props: {
            theme_color: {
                type: String,
                default: 'rgb(0, 163, 82)'
            }
        }
    }
</script>


