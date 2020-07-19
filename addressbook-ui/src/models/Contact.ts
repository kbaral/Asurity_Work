import {Address} from './Address';

export class Contact {
    public Id: number;
    public FirstName: string;
    public LastName: string;
    public Email: string;
    public Address: Address;
    public PhoneNumber: string;
    public ContactFrequency: string;
    public PreferredContactMethod: string;

    constructor(args: any) {
        this.Id = args.Id;
        this.FirstName = args.FirstName;
        this.LastName = args.LastName;
        this.Email = args.Email;
        this.Address = args.Address;
        this.PhoneNumber = args.PhoneNumber;
        this.ContactFrequency = args.ContactFrequency;
        this.PreferredContactMethod = args.PreferredContactMethod;
    }
}
