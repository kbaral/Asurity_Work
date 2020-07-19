export class DropDownOptions {
    public ContactFreqOptions: string[];
    public ContactMethodOptions: string[];

    constructor(args: any) {
        this.ContactFreqOptions = args.ContactFreqOptions;
        this.ContactMethodOptions = args.ContactMethodOptions;
    }
}
