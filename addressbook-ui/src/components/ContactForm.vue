<template>
  <div>
    <h3>{{formHeading}}</h3>
    <b-form @submit="addOrUpdate">
      
      <b-form-row>
        <b-col>
          <b-form-group label="First Name" label-for="firstname">
            <b-form-input
              id="firstname"
              v-model="newContact.FirstName"
              required
              :maxlength="20"
              placeholder="Enter first name"
            ></b-form-input>
          </b-form-group>
        </b-col>
        <b-col>
          <b-form-group label="Last Name" label-for="lastname">
            <b-form-input
              id="lastname"
              v-model="newContact.LastName"
              required
              :maxlength="20"
              placeholder="Enter last name"
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-form-row>     
      <b-form-row>
        <b-col>
          <b-form-group label="Email address" label-for="email">
            <b-form-input
              id="email"
              v-model="newContact.Email"
              type="email"
              required
              placeholder="Enter email"
            ></b-form-input>
          </b-form-group>
        </b-col>
        <b-col>
          <b-form-group label="Phone Number" label-for="phone">
            <b-form-input
              id="phone"
              v-model="newContact.PhoneNumber"
              required
              :maxlength="15"
              placeholder="Enter phone number"
            ></b-form-input>
          </b-form-group>
        </b-col>
      </b-form-row>
      <label>Address</label>
      <b-form-row>
        <b-col>
          <b-form-group label="Street" label-for="street">
            <b-form-input
              id="street"
              v-model="newContact.Address.Street"
              required
              :maxlength="100"
              placeholder="Enter street"
            ></b-form-input>
          </b-form-group> 
        </b-col>
        <b-col>
          <b-form-group label="City" label-for="city">
            <b-form-input
              id="city"
              v-model="newContact.Address.City"
              required
              :maxlength="50"
              placeholder="Enter city"
            ></b-form-input>
          </b-form-group> 
        </b-col>
      </b-form-row>  
      <b-form-row>
        <b-col>
          <b-form-group label="State" label-for="state">
            <b-form-select
              id="state"
              v-model="newContact.Address.State"
              :options="states"
              required
            ></b-form-select>
          </b-form-group>
        </b-col>
        <b-col>
          <b-form-group label="zip" label-for="zip">
            <b-form-input
              id="zip"
              v-model="newContact.Address.Zip"
              required
              placeholder="Enter zip"
            ></b-form-input>
          </b-form-group> 
        </b-col>
      </b-form-row>  
      <b-form-row>
        <b-col>
          <b-form-group label="Contact Frequency" label-for="ContactFrequency">
            <b-form-select
              id="ContactFrequency"
              v-model="newContact.ContactFrequency"
              :options="ContactFrequency"
              required
            ></b-form-select>
          </b-form-group>
        </b-col>
        <b-col>
          <b-form-group label="Preferred Contact Method" label-for="PreferredContactMethod">
            <b-form-select
              id="PreferredContactMethod"
              v-model="newContact.PreferredContactMethod"
              :options="PreferredContactMethod"
              required
            ></b-form-select>
          </b-form-group>
        </b-col>
      </b-form-row>      

      <b-button v-if="newContact.Id > 0" type="submit" variant="primary">Update</b-button>
      <b-button v-else type="submit" variant="primary">Submit</b-button>
      <b-button class="ml-2" variant="outline-secondary" @click="goBack()">back</b-button>
    </b-form>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { apiService } from '@/services/ApiServices';
import { Contact } from '../models/Contact';
import { Address } from '../models/Address';
import { State } from '../models/State';
import { DropDownOptions } from '../models/DropDownOptions';

@Component
export default class NewContactForm extends Vue {

    private formHeading: string = '';
    private newContact: Contact = new Contact({
      Address: new Address({}),
    });
    
    private isInvalid: boolean = false;
    private isSubmitted: boolean = false;

    // Computed properties fetching it from app store.
    get states() : Array<State> {
        return this.$store.state.statesDropDownOptions.map((s: State) => {
          return new Object({ text: s.Name, value: s.ShortName });
        });
    }

    get ContactFrequency() : Array<string> {        
        return this.$store.state.dropDownOptions.ContactFreqOptions;
    }
    
    get PreferredContactMethod() : Array<string> {
        return this.$store.state.dropDownOptions.ContactMethodOptions;
    }

    private created() {
      this.formHeading = 'Add Contact';
      if (this.$route.name === 'Edit') {
        this.formHeading = 'Edit Contact';
        apiService.getContactById(this.$route.params.id).then((contact: Contact) => {
          this.newContact = contact;
        });
      }
    }

    private addOrUpdate() {
        this.isSubmitted = true;
        if (this.newContact.Id > 0) {
          apiService.updateContact(this.newContact).then((isUpdated: boolean) => {
            this.isSubmitted = false;
            if (isUpdated) {
              this.goBack();
            }
          });
        } else {
          apiService.addNewContact(this.newContact).then((contact: Contact) => {
            this.isSubmitted = false;
            this.goBack();
          });
        }
    }

    private invalidFeedback() {
        let result = '';
        if (this.newContact.FirstName.length === 0) {
            result = 'Please enter something';
        }
        return result;
    }

    private getState() {
        let result = null;
        if (this.isInvalid && this.isSubmitted) {
          result = false;
        }
        if (!this.isInvalid && this.isSubmitted) {
          result = true;
        }
        return result;
    }

    private goBack() {
        this.$router.push('/');
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
