import axios from 'axios';
import {Contact} from '../models/Contact';
import { State } from '@/models/State';
import { Address } from '@/models/Address';
import { DropDownOptions } from '@/models/DropDownOptions';

class ApiService {
    //private baseServiceEndpoint = 'https://localhost:44314/api/';
    private baseServiceEndpoint = 'https://localhost:5001/api/';

    /**
     * Gets all contacts
     *
     * @returns {Promise<Contact[]>} Returns promise that contains all contacts info.
     */
    public getAllContacts = async (): Promise<Contact[]> => {
        const url = this.baseServiceEndpoint + 'contacts';
        return axios.get(url).then((res: any) => {
            const contacts = res.data.map((contact: any) => {
                const address = new Address({
                    Street: contact.address ? contact.address.street : '',
                    City: contact.address ? contact.address.city : '',
                    State: contact.address ? contact.address.state : '',
                    Zip: contact.address ? contact.address.zip : '',
                });

                return new Contact({
                    Id: contact.id,
                    FirstName: contact.firstName,
                    LastName: contact.lastName,
                    Email: contact.email,
                    Address: address,
                    PhoneNumber: contact.phoneNumber,
                    ContactFrequency: contact.contactFrequency,
                    PreferredContactMethod: contact.preferredContactMethod,
                });
            });
            return contacts;
        });
    }

    /**
     * Adds new contact
     *
     * @returns {Promise<Contact>} Returns promise that contains new contact info.
     */
    public addNewContact = async (newContact: Contact): Promise<Contact> => {
        const url = this.baseServiceEndpoint + 'contacts';
        return axios.post(url, JSON.stringify(newContact), {responseType: 'json', headers: { 'Content-Type': 'application/json'}}).then((res: any) => {
            newContact.Id = res.data;
            return newContact;
        });
    }

    /**
     * Gets contact by ID
     *
     * @returns {Promise<Contact>} Returns promise that contains contact info.
     */
    public getContactById = async (id: string): Promise<Contact> => {
        const url = this.baseServiceEndpoint + 'contacts/' + id;
        return axios.get(url).then((res: any) => {
            const data = res.data;
            const address = new Address({
                Street: data.address ? data.address.street : '',
                City: data.address ? data.address.city : '',
                State: data.address ? data.address.state : '',
                Zip: data.address ? data.address.zip : '',
            });
            return new Contact({
                Id: data.id,
                FirstName: data.firstName,
                LastName: data.lastName,
                Email: data.email,
                Address: address,
                PhoneNumber: data.phoneNumber,
                ContactFrequency: data.contactFrequency,
                PreferredContactMethod: data.preferredContactMethod,
            });
        });
    }

    /**
     * Updates contact by ID
     *
     * @returns {Promise<boolean>} Returns promise isUpdated boolean.
     */
    public updateContact = async (contact: Contact): Promise<boolean> => {
        const url = this.baseServiceEndpoint + 'contacts/' + contact.Id;
        return axios.put(url, JSON.stringify(contact), {responseType: 'json', headers: { 'Content-Type': 'application/json'}}).then((res: any) => {
            return res.data;
        });
    }

    /**
     * Deletes contact by ID
     *
     * @returns {Promise<boolean>} Returns promise.
     */
    public deleteContact = async (id: number): Promise<boolean> => {
        const url = this.baseServiceEndpoint + 'contacts/' + id;
        return axios.delete(url).then((res: any) => {
            return res.data;
        });
    }

    /**
     * Gets all states
     *
     * @returns {Promise<State[]>} Returns promise that contains all states info.
     */
    public getAllStates = async (): Promise<State[]> => {
        const url = this.baseServiceEndpoint + 'states';
        return axios.get(url).then((res: any) => {
            const states = res.data.map((contact: any) => {
                return new State({
                    Name: contact.name,
                    ShortName: contact.shortName,
                });
            });
            return states;
        });
    }

    /**
     * Gets all dropDownOptions
     *
     * @returns {Promise<DropDownOptions>} Returns promise that contains dropDownOptions.
     */
    public getAllDropDownOptions = async (): Promise<DropDownOptions> => {
        const url = this.baseServiceEndpoint + 'Constants';
        return axios.get(url).then((res: any) => {
            return new DropDownOptions({
                ContactFreqOptions: res.data.contactFreqOptions,
                ContactMethodOptions: res.data.contactMethodOptions,
            });
        });
    }
}

export const apiService = new ApiService();
