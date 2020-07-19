<template>
  <div>
    <h3>
      Contacts 
      <b-button variant="primary" class="ml-auto pull-right" @click="goToAdd()">Add New</b-button>
    </h3> 

    <b-table outlined striped hover :items="contacts" :fields="fields">
      <template v-slot:cell(city)="row" >
        {{ row.item.Address.City }}
      </template>
      <template v-slot:cell(state)="row" >
        {{ row.item.Address.State }}
      </template>
      <template v-slot:cell(actions)="row">
        <b-button size="sm" variant="outline-primary" @click="goToUpdate(row.item)" class="mr-1">
          Edit
        </b-button>
        <b-button size="sm" variant="outline-danger" @click="deleteContact(row.item)">
          Delete
        </b-button>
      </template>
    </b-table>
    <!-- <div v-for="contact in contacts" v-bind:key="contact.id" v-on:click="HandleOnNodeClick(contact)">
        <label>{{ contact.FirstName }}</label>
    </div>   -->
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { apiService } from '@/services/ApiServices';
import { Contact } from '../models/Contact';

@Component
export default class ContactsGrid extends Vue {

    // Data property
    private contacts: Contact[] = [];
    private fields = [
      {
        key: 'FirstName',
        label: 'First Name',
        sortable: true,
      },
      {
        key: 'LastName',
        label: 'Last Name',
        sortable: false,
      },
      {
        key: 'city',
        label: 'City',
      },
      {
        key: 'state',
        label: 'State',
      },
      {
        key: 'PhoneNumber',
        label: 'Phone Number',
      },
      { key: 'actions', label: 'Actions' },
    ];

    // Lifecycle hook
    private created() {
        apiService.getAllContacts().then((res: Contact[]) => {
            this.contacts = res;
        });
    }

    private goToAdd() {
        this.$router.push('add');
    }

    private goToUpdate(contact: Contact) {
      this.$router.push('edit/' + contact.Id);
    }

    private deleteContact(contact: Contact) {
      apiService.deleteContact(contact.Id).then((isDeleted: boolean) => {
        if (isDeleted) {
          this.contacts.splice(this.contacts.indexOf(contact), 1);
        }
      });
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.pull-right{
  float: right;
}
</style>
