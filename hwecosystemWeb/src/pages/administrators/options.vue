<template>
  <div class="q-pa-md">
    <div class="q-gutter-y-md">
      <q-card>
        <q-tabs
          v-model="subjects"
          dense
          class="text-grey"
          active-color="primary"
          indicator-color="primary"
          align="justify"
          narrow-indicator
        >
          <q-tab name="primarysubjects" label="Primary Subjects" />
          <q-tab name="secondarysubjects" label="Secondary Subjects" />
        </q-tabs>

        <q-separator />

        <q-tab-panels v-model="subjects" animated>
          <q-tab-panel name="primarysubjects">
            <primaryoptions-app></primaryoptions-app>
          </q-tab-panel>

          <q-tab-panel name="secondarysubjects">
            <secondaryoptions-app></secondaryoptions-app>
          </q-tab-panel>
        </q-tab-panels>
      </q-card>

    </div>
  </div>
</template>

<script>
import primaryoptions from 'components/administrators/primaryoptions.vue';
import secondaryoptions from 'components/administrators/secondaryoptions.vue';
export default {
    components: {
        'primaryoptions-app' : primaryoptions,
        'secondaryoptions-app' : secondaryoptions
    },
  data () {
    return {
      subjects: 'subjects'
    }
  }
}
</script>

<style scoped>

</style>