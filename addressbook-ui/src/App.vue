<template>
  <div id="app">
    <div>
			<b-navbar type="dark" variant="primary">
				<b-navbar-brand href="#">
					Address Book
				</b-navbar-brand>
        <b-navbar-nav>
          <router-link to="/">Home</router-link>
          <router-link to="/about">About</router-link>
        </b-navbar-nav>
			</b-navbar>
		</div>
    
    	<div class="p-3">
        <router-view />
    	</div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
import {Component} from 'vue-property-decorator';

@Component
export default class App extends Vue {
  // Lifecycle hook
  beforeCreate(){
    this.$store.dispatch('getStates');
    this.$store.dispatch('getConstants');
  }
  
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

.navbar-nav a{
  color: black;
  padding-right: 20px;
}
</style>
