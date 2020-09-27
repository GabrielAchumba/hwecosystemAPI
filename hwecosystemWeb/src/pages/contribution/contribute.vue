<template>
  <div class="q-pa-md">
    <div class="q-gutter-y-md">
      <q-card>
        <q-tabs
          v-model="tab"
          dense
          class="text-grey"
          active-color="primary"
          indicator-color="primary"
          align="justify"
          narrow-indicator
        >
          <q-tab name="onplatformpayment" label="On-Platform Payment" />
          <q-tab name="offplatformpayment" label="Off-Platform Payment" />
        </q-tabs>

        <q-separator />

        <q-tab-panels v-model="tab" animated>
          <q-tab-panel name="onplatformpayment">
            <onPlatformPayment-app></onPlatformPayment-app>

          </q-tab-panel>

          <q-tab-panel name="offplatformpayment">
            <offPlatformPayment-app></offPlatformPayment-app>
          </q-tab-panel>
        </q-tab-panels>

      </q-card>

    </div>
  </div>
</template>

<script>
import offPlatformPayment from 'pages/contribution/offPlatformPayment.vue'
import onPlatformPayment from 'pages/contribution/onPlatformPayment.vue' 
export default {
    components: {
            'offPlatformPayment-app': offPlatformPayment,
            'onPlatformPayment-app': onPlatformPayment
        },
  data () {
    return {
      tab: 'onplatformpayment'
    }
  }
}
</script>