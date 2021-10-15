namespace SendMailSharp;
        // class declarations
         class Mail;
     class Mail 
    {
        // class delegates
        delegate INTEGER_FUNCTION OutputDelegate ( SIMPLSHARPSTRING str );

        // class events

        // class functions
        STRING_FUNCTION SendEMail ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        STRING server[];
        INTEGER port;
        STRING user[];
        STRING password[];
        STRING sendFrom[];
        STRING sendTo[];
        STRING sendCC[];
        STRING subject[];
        STRING body[];
        SIGNED_INTEGER err;
        STRING errmsg[];
        INTEGER attachmentnum;
        STRING attachment[];

        // class properties
        DelegateProperty OutputDelegate myDel;
    };

