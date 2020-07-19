export class Address {
    public Street: string;
    public City: string;
    public State: string;
    public Zip: string;

    constructor(args: any) {
        this.Street = args.Street;
        this.City = args.City;
        this.State = args.State;
        this.Zip = args.Zip;
    }
}
