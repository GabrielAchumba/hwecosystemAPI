<template>
  <div>
      <q-toolbar class="flex flex-center text-white" style="background-color: #1c1b21;" :style="'border-top: 2px solid '+ theme_color">
           <div class="q-pa-sm q-gutter-sm">
	    <q-btn round type="a" href="https://www.ushops.org"
                     :style="'background:'+ theme_color +'; color: white !important;'" icon="fab fa-twitter" />
	    <q-btn round type="a" href="https://www.ushops.org"
                     :style="'background:'+ theme_color +'; color: white !important;'" icon="fab fa-github" />
            <q-btn round type="a" href="https://www.ushops.org"
                     :style="'background:'+ theme_color +'; color: white !important;'" icon="email" />
	    <q-btn round type="a" href="https://www.ushops.org"
                     :style="'background:'+ theme_color +'; color: white !important;'" glossy text-color="black" icon="fas fa-heart" />
	  </div>
        </q-toolbar>
  </div>
</template>

<script>

    export default {
        props: {
            active: {
            type: Boolean,
            default: false
            },
            background_style: {
            type: String,
            default: 'background-color:rgba(0, 163, 82, 0.7);'
            },
            theme_color: {
            type: String,
            default: 'rgb(0, 163, 82)'
            },
            hover: {
            type: Boolean,
            default: false
            }
        }
    }
</script>

<style>
</style>
