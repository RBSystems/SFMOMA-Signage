using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace UserModule_BIAMP_TESIRA_COMMAND_PROCESSOR_V1_5
{
    public class UserModuleClass_BIAMP_TESIRA_COMMAND_PROCESSOR_V1_5 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput IS_RS232;
        Crestron.Logos.SplusObjects.DigitalInput CONNECT;
        Crestron.Logos.SplusObjects.DigitalInput DISCONNECT;
        Crestron.Logos.SplusObjects.BufferInput FROM_DEVICE__DOLLAR__;
        Crestron.Logos.SplusObjects.BufferInput FROM_MODULES__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.DigitalOutput IS_COMMUNICATING;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TO_MODULES__DOLLAR__;
        _MODULECOMM [] MODULECOMM;
        _COMMQUEUE QUEUECOMM;
        CrestronString [] SCOMMANDQUEUE;
        CrestronString [] SSTATUSQUEUE;
        ushort PARSINGDEVICEBUSY = 0;
        CrestronString PARSEDDEVICEMSG;
        CrestronString ECHODEVICEMSG;
        ushort RESPONSEMSGID = 0;
        ushort PARSINGMODULEBUSY = 0;
        CrestronString PARSEDMODULEMSG;
        CrestronString TRASH;
        ushort RESPONSEMODULEMSGID = 0;
        ushort INITMODULEID = 0;
        ushort REGMODULEID = 0;
        ushort ISINITIALIZING = 0;
        ushort ISREGISTERING = 0;
        ushort ISHEARTBEATING = 0;
        ushort ISRS232 = 0;
        private ushort STARTSWITH (  SplusExecutionContext __context__, CrestronString MATCH_STRING , CrestronString SOURCE_STRING ) 
            { 
            
            __context__.SourceCodeLine = 170;
            return (ushort)( Functions.BoolToInt (Functions.Find( MATCH_STRING , SOURCE_STRING ) == 1)) ; 
            
            }
            
        private ushort CONTAINS (  SplusExecutionContext __context__, CrestronString MATCH_STRING , CrestronString SOURCE_STRING ) 
            { 
            
            __context__.SourceCodeLine = 175;
            return (ushort)( Functions.BoolToInt ( Functions.Find( MATCH_STRING , SOURCE_STRING ) > 0 )) ; 
            
            }
            
        private CrestronString REMOVEALL (  SplusExecutionContext __context__, CrestronString SOURCE , CrestronString REMOVEITEM ) 
            { 
            CrestronString PIECE;
            PIECE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3000, this );
            
            CrestronString RESPONSE;
            RESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3000, this );
            
            
            __context__.SourceCodeLine = 183;
            RESPONSE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 184;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( REMOVEITEM , SOURCE ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 186;
                PIECE  .UpdateValue ( Functions.Remove ( REMOVEITEM , SOURCE )  ) ; 
                __context__.SourceCodeLine = 188;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( PIECE ) == Functions.Length( REMOVEITEM )))  ) ) 
                    {
                    __context__.SourceCodeLine = 189;
                    PIECE  .UpdateValue ( ""  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 191;
                    PIECE  .UpdateValue ( Functions.Left ( PIECE ,  (int) ( (Functions.Length( PIECE ) - Functions.Length( REMOVEITEM )) ) )  ) ; 
                    }
                
                __context__.SourceCodeLine = 193;
                MakeString ( RESPONSE , "{0}{1}", RESPONSE , PIECE ) ; 
                __context__.SourceCodeLine = 184;
                } 
            
            __context__.SourceCodeLine = 196;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOURCE ) > 0 ))  ) ) 
                {
                __context__.SourceCodeLine = 197;
                MakeString ( RESPONSE , "{0}{1}", RESPONSE , SOURCE ) ; 
                }
            
            __context__.SourceCodeLine = 199;
            return ( RESPONSE ) ; 
            
            }
            
        private CrestronString GETBOUNDSTRING (  SplusExecutionContext __context__, CrestronString SOURCE , CrestronString STARTSTRING , CrestronString ENDSTRING ) 
            { 
            ushort STARTINDEX = 0;
            
            ushort ENDINDEX = 0;
            
            CrestronString RESPONSE;
            RESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            
            __context__.SourceCodeLine = 212;
            RESPONSE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 214;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOURCE ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 216;
                STARTINDEX = (ushort) ( Functions.Find( STARTSTRING , SOURCE ) ) ; 
                __context__.SourceCodeLine = 217;
                ENDINDEX = (ushort) ( Functions.Find( ENDSTRING , SOURCE , (STARTINDEX + 1) ) ) ; 
                __context__.SourceCodeLine = 219;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX < ENDINDEX ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 221;
                    STARTINDEX = (ushort) ( (STARTINDEX + Functions.Length( STARTSTRING )) ) ; 
                    __context__.SourceCodeLine = 223;
                    RESPONSE  .UpdateValue ( Functions.Mid ( SOURCE ,  (int) ( STARTINDEX ) ,  (int) ( (ENDINDEX - STARTINDEX) ) )  ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 227;
            return ( RESPONSE ) ; 
            
            }
            
        private ushort GETMSGID (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 232;
            return (ushort)( Functions.Atoi( GETBOUNDSTRING( __context__ , MSG , "<" , "|" ) )) ; 
            
            }
            
        private ushort GETSUBSCRIBEDMSGID (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 237;
            return (ushort)( Functions.Atoi( GETBOUNDSTRING( __context__ , MSG , "[" , "*" ) )) ; 
            
            }
            
        private CrestronString GETMSG (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            CrestronString ITEM;
            ITEM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            
            __context__.SourceCodeLine = 244;
            ITEM  .UpdateValue ( GETBOUNDSTRING (  __context__ , MSG, "|", ">")  ) ; 
            __context__.SourceCodeLine = 246;
            return ( ITEM ) ; 
            
            }
            
        private void INITQUEUE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 254;
            QUEUECOMM . NBUSY = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 255;
            QUEUECOMM . NHASITEMS = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 256;
            QUEUECOMM . NCOMMANDHEAD = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 257;
            QUEUECOMM . NCOMMANDTAIL = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 258;
            QUEUECOMM . NSTATUSHEAD = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 259;
            QUEUECOMM . NSTATUSTAIL = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 260;
            QUEUECOMM . NSTRIKECOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 261;
            QUEUECOMM . NRESENDLAST = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 262;
            QUEUECOMM . SLASTMESSAGE  .UpdateValue ( ""  ) ; 
            
            }
            
        private void INITMODULES (  SplusExecutionContext __context__ ) 
            { 
            ushort ID = 0;
            
            
            __context__.SourceCodeLine = 269;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISINITIALIZING == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 271;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( INITMODULEID ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)Functions.GetNumArrayRows( TO_MODULES__DOLLAR__ ); 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( ID  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ID  >= __FN_FORSTART_VAL__1) && (ID  <= __FN_FOREND_VAL__1) ) : ( (ID  <= __FN_FORSTART_VAL__1) && (ID  >= __FN_FOREND_VAL__1) ) ; ID  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 273;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( MODULECOMM[ ID ].ISREGISTERED ) && Functions.TestForTrue ( Functions.BoolToInt (MODULECOMM[ ID ].ISINITIALIZED == 0) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 275;
                        ISINITIALIZING = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 277;
                        MakeString ( TO_MODULES__DOLLAR__ [ ID] , "INIT<{0:d}>", (short)ID) ; 
                        __context__.SourceCodeLine = 279;
                        INITMODULEID = (ushort) ( ID ) ; 
                        __context__.SourceCodeLine = 281;
                        break ; 
                        } 
                    
                    __context__.SourceCodeLine = 284;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ID == Functions.GetNumArrayRows( TO_MODULES__DOLLAR__ )) ) && Functions.TestForTrue ( Functions.BoolToInt (ISINITIALIZING == 0) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 286;
                        INITMODULEID = (ushort) ( ID ) ; 
                        __context__.SourceCodeLine = 287;
                        IS_INITIALIZED  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 271;
                    } 
                
                } 
            
            
            }
            
        private void REINIT (  SplusExecutionContext __context__ ) 
            { 
            ushort ID = 0;
            
            
            __context__.SourceCodeLine = 297;
            INITMODULEID = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 298;
            ISINITIALIZING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 299;
            IS_INITIALIZED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 301;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.GetNumArrayCols( MODULECOMM ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( ID  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (ID  >= __FN_FORSTART_VAL__1) && (ID  <= __FN_FOREND_VAL__1) ) : ( (ID  <= __FN_FORSTART_VAL__1) && (ID  >= __FN_FOREND_VAL__1) ) ; ID  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 302;
                MODULECOMM [ ID] . ISINITIALIZED = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 301;
                }
            
            
            }
            
        private void RESET (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 307;
            REINIT (  __context__  ) ; 
            __context__.SourceCodeLine = 308;
            INITQUEUE (  __context__  ) ; 
            
            }
            
        private ushort ISQUEUEEMPTY (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 316;
            return (ushort)( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (QUEUECOMM.NHASITEMS == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (QUEUECOMM.NBUSY == 0) )) )) ; 
            
            }
            
        private CrestronString DEQUEUE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SRESPONSE;
            SRESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            
            __context__.SourceCodeLine = 323;
            SRESPONSE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 325;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (QUEUECOMM.NHASITEMS == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (QUEUECOMM.NBUSY == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 327;
                QUEUECOMM . NBUSY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 330;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NCOMMANDHEAD != QUEUECOMM.NCOMMANDTAIL))  ) ) 
                    { 
                    __context__.SourceCodeLine = 332;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NCOMMANDTAIL == Functions.GetNumArrayRows( SCOMMANDQUEUE )))  ) ) 
                        {
                        __context__.SourceCodeLine = 333;
                        QUEUECOMM . NCOMMANDTAIL = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 335;
                        QUEUECOMM . NCOMMANDTAIL = (ushort) ( (QUEUECOMM.NCOMMANDTAIL + 1) ) ; 
                        }
                    
                    __context__.SourceCodeLine = 337;
                    QUEUECOMM . SLASTMESSAGE  .UpdateValue ( SCOMMANDQUEUE [ QUEUECOMM.NCOMMANDTAIL ]  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 340;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NSTATUSHEAD != QUEUECOMM.NSTATUSTAIL))  ) ) 
                        { 
                        __context__.SourceCodeLine = 342;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NSTATUSTAIL == Functions.GetNumArrayRows( SSTATUSQUEUE )))  ) ) 
                            {
                            __context__.SourceCodeLine = 343;
                            QUEUECOMM . NSTATUSTAIL = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 345;
                            QUEUECOMM . NSTATUSTAIL = (ushort) ( (QUEUECOMM.NSTATUSTAIL + 1) ) ; 
                            }
                        
                        __context__.SourceCodeLine = 347;
                        QUEUECOMM . SLASTMESSAGE  .UpdateValue ( SSTATUSQUEUE [ QUEUECOMM.NSTATUSTAIL ]  ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 350;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (QUEUECOMM.NCOMMANDHEAD == QUEUECOMM.NCOMMANDTAIL) ) && Functions.TestForTrue ( Functions.BoolToInt (QUEUECOMM.NSTATUSHEAD == QUEUECOMM.NSTATUSTAIL) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 351;
                    QUEUECOMM . NHASITEMS = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 353;
                SRESPONSE  .UpdateValue ( GETMSG (  __context__ , QUEUECOMM.SLASTMESSAGE)  ) ; 
                } 
            
            __context__.SourceCodeLine = 356;
            return ( SRESPONSE ) ; 
            
            }
            
        private void SENDNEXTQUEUEITEM (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SOUTGOING;
            SOUTGOING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            
            __context__.SourceCodeLine = 363;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NRESENDLAST == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 365;
                QUEUECOMM . NRESENDLAST = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 366;
                SOUTGOING  .UpdateValue ( GETMSG (  __context__ , QUEUECOMM.SLASTMESSAGE)  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 370;
                SOUTGOING  .UpdateValue ( DEQUEUE (  __context__  )  ) ; 
                } 
            
            __context__.SourceCodeLine = 373;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOUTGOING ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 375;
                MakeString ( TO_DEVICE__DOLLAR__ , "{0}\u000a", SOUTGOING ) ; 
                __context__.SourceCodeLine = 377;
                CreateWait ( "QUEUEFALSERESPONSE" , 250 , QUEUEFALSERESPONSE_Callback ) ;
                } 
            
            
            }
            
        public void QUEUEFALSERESPONSE_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 379;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NBUSY == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 381;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( QUEUECOMM.NSTRIKECOUNT < 3 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 383;
                    QUEUECOMM . NSTRIKECOUNT = (ushort) ( (QUEUECOMM.NSTRIKECOUNT + 1) ) ; 
                    __context__.SourceCodeLine = 385;
                    /* Trace( "!!!FAILED Response{{{0}}}", QUEUECOMM . SLASTMESSAGE ) */ ; 
                    __context__.SourceCodeLine = 387;
                    QUEUECOMM . NRESENDLAST = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 389;
                    SENDNEXTQUEUEITEM (  __context__  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 393;
                    IS_COMMUNICATING  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 394;
                    RESET (  __context__  ) ; 
                    } 
                
                } 
            
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void ENQUEUE (  SplusExecutionContext __context__, CrestronString SCMD , ushort BPRIORITY ) 
        { 
        ushort NQUEUEWASEMPTY = 0;
        
        
        __context__.SourceCodeLine = 405;
        NQUEUEWASEMPTY = (ushort) ( ISQUEUEEMPTY( __context__ ) ) ; 
        __context__.SourceCodeLine = 407;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BPRIORITY == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 409;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NCOMMANDHEAD == Functions.GetNumArrayRows( SCOMMANDQUEUE )))  ) ) 
                { 
                __context__.SourceCodeLine = 411;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NCOMMANDTAIL != 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 413;
                    QUEUECOMM . NCOMMANDHEAD = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 414;
                    SCOMMANDQUEUE [ QUEUECOMM.NCOMMANDHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 415;
                    QUEUECOMM . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 418;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NCOMMANDTAIL != (QUEUECOMM.NCOMMANDHEAD + 1)))  ) ) 
                    { 
                    __context__.SourceCodeLine = 420;
                    QUEUECOMM . NCOMMANDHEAD = (ushort) ( (QUEUECOMM.NCOMMANDHEAD + 1) ) ; 
                    __context__.SourceCodeLine = 421;
                    SCOMMANDQUEUE [ QUEUECOMM.NCOMMANDHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 422;
                    QUEUECOMM . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                }
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 427;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NSTATUSHEAD == Functions.GetNumArrayRows( SSTATUSQUEUE )))  ) ) 
                { 
                __context__.SourceCodeLine = 429;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NSTATUSTAIL != 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 431;
                    QUEUECOMM . NSTATUSHEAD = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 432;
                    SSTATUSQUEUE [ QUEUECOMM.NSTATUSHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 433;
                    QUEUECOMM . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 436;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (QUEUECOMM.NSTATUSTAIL != (QUEUECOMM.NSTATUSHEAD + 1)))  ) ) 
                    { 
                    __context__.SourceCodeLine = 438;
                    QUEUECOMM . NSTATUSHEAD = (ushort) ( (QUEUECOMM.NSTATUSHEAD + 1) ) ; 
                    __context__.SourceCodeLine = 439;
                    SSTATUSQUEUE [ QUEUECOMM.NSTATUSHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 440;
                    QUEUECOMM . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                }
            
            } 
        
        __context__.SourceCodeLine = 444;
        if ( Functions.TestForTrue  ( ( NQUEUEWASEMPTY)  ) ) 
            {
            __context__.SourceCodeLine = 445;
            SENDNEXTQUEUEITEM (  __context__  ) ; 
            }
        
        
        }
        
    private void GOODRESPONSE (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 451;
        /* Trace( "GOOD Response{{{0}}}", QUEUECOMM . SLASTMESSAGE ) */ ; 
        __context__.SourceCodeLine = 453;
        QUEUECOMM . NBUSY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 455;
        CancelWait ( "QUEUEFALSERESPONSE" ) ; 
        __context__.SourceCodeLine = 457;
        QUEUECOMM . NSTRIKECOUNT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 459;
        QUEUECOMM . NRESENDLAST = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 461;
        SENDNEXTQUEUEITEM (  __context__  ) ; 
        
        }
        
    private void SENDHEARTBEAT (  SplusExecutionContext __context__ ) 
        { 
        CrestronString OUTGOINGMSG;
        OUTGOINGMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
        
        
        __context__.SourceCodeLine = 471;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISHEARTBEATING == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 473;
            if ( Functions.TestForTrue  ( ( ISQUEUEEMPTY( __context__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 475;
                MakeString ( OUTGOINGMSG , "POLL_MSG<HEARTBEAT|{0}>", "DEVICE get version" ) ; 
                __context__.SourceCodeLine = 477;
                ENQUEUE (  __context__ , OUTGOINGMSG, (ushort)( 0 )) ; 
                } 
            
            __context__.SourceCodeLine = 480;
            CreateWait ( "HEARTBEAT" , 3000 , HEARTBEAT_Callback ) ;
            } 
        
        
        }
        
    public void HEARTBEAT_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            
            __context__.SourceCodeLine = 482;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISHEARTBEATING == 1))  ) ) 
                {
                __context__.SourceCodeLine = 483;
                SENDHEARTBEAT (  __context__  ) ; 
                }
            
            
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void STARTHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    CrestronString OUTGOINGMSG;
    OUTGOINGMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    
    
    __context__.SourceCodeLine = 492;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISHEARTBEATING == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 494;
        ISHEARTBEATING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 496;
        SENDHEARTBEAT (  __context__  ) ; 
        } 
    
    
    }
    
private void STOPHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 502;
    ISHEARTBEATING = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 504;
    CancelWait ( "HEARTBEAT" ) ; 
    
    }
    
private void SETISCOMMUNICATING (  SplusExecutionContext __context__ ) 
    { 
    CrestronString OUTGOINGMSG;
    OUTGOINGMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    
    
    __context__.SourceCodeLine = 511;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_COMMUNICATING  .Value == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 514;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISRS232 == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 517;
            MakeString ( TO_DEVICE__DOLLAR__ , "{0}", "exit\r\n" ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 521;
            MakeString ( OUTGOINGMSG , "POLL_MSG<VERBOSE|{0}>", "SESSION set verbose false" ) ; 
            __context__.SourceCodeLine = 523;
            ENQUEUE (  __context__ , OUTGOINGMSG, (ushort)( 0 )) ; 
            } 
        
        } 
    
    
    }
    
private void REGISTRATIONPROCESS (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 534;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( REGMODULEID < Functions.GetNumArrayRows( TO_MODULES__DOLLAR__ ) ))  ) ) 
        { 
        __context__.SourceCodeLine = 536;
        REGMODULEID = (ushort) ( (REGMODULEID + 1) ) ; 
        __context__.SourceCodeLine = 538;
        MakeString ( TO_MODULES__DOLLAR__ [ REGMODULEID] , "REGISTER<{0:d}>", (short)REGMODULEID) ; 
        __context__.SourceCodeLine = 540;
        CreateWait ( "REGISTRATIONWAIT" , 10 , REGISTRATIONWAIT_Callback ) ;
        } 
    
    else 
        {
        __context__.SourceCodeLine = 547;
        ISREGISTERING = (ushort) ( 0 ) ; 
        }
    
    
    }
    
public void REGISTRATIONWAIT_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            
            __context__.SourceCodeLine = 542;
            if ( Functions.TestForTrue  ( ( ISREGISTERING)  ) ) 
                {
                __context__.SourceCodeLine = 543;
                REGISTRATIONPROCESS (  __context__  ) ; 
                }
            
            
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void STARTREGISTRATION (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 552;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ISREGISTERING == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 554;
        ISREGISTERING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 555;
        REGMODULEID = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 556;
        REGISTRATIONPROCESS (  __context__  ) ; 
        } 
    
    
    }
    
private void STOPREGISTRATION (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 562;
    CancelWait ( "REGISTRATIONWAIT" ) ; 
    __context__.SourceCodeLine = 563;
    ISREGISTERING = (ushort) ( 0 ) ; 
    
    }
    
private void PROCESSMODULEMSG (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 583;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PARSEDMODULEMSG ) > 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 585;
        if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "POLL_MSG" , PARSEDMODULEMSG ))  ) ) 
            { 
            __context__.SourceCodeLine = 587;
            ENQUEUE (  __context__ , PARSEDMODULEMSG, (ushort)( 0 )) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 589;
            if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "COMMAND_MSG" , PARSEDMODULEMSG ))  ) ) 
                { 
                __context__.SourceCodeLine = 591;
                ENQUEUE (  __context__ , PARSEDMODULEMSG, (ushort)( 1 )) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 593;
                if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "RESPONSE_OK" , PARSEDMODULEMSG ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 595;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.CompareStrings( GETBOUNDSTRING( __context__ , PARSEDMODULEMSG , "<" , ">" ) , GETBOUNDSTRING( __context__ , QUEUECOMM.SLASTMESSAGE , "<" , ">" ) ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 596;
                        GOODRESPONSE (  __context__  ) ; 
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 598;
                    if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "INIT_DONE" , PARSEDMODULEMSG ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 600;
                        ISINITIALIZING = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 602;
                        RESPONSEMODULEMSGID = (ushort) ( Functions.Atoi( GETBOUNDSTRING( __context__ , PARSEDMODULEMSG , "<" , ">" ) ) ) ; 
                        __context__.SourceCodeLine = 604;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMODULEMSGID > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMODULEMSGID <= Functions.GetNumArrayCols( MODULECOMM ) ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 606;
                            MODULECOMM [ RESPONSEMODULEMSGID] . ISINITIALIZED = (ushort) ( 1 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 609;
                        INITMODULES (  __context__  ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 611;
                        if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "REGISTER" , PARSEDMODULEMSG ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 613;
                            RESPONSEMODULEMSGID = (ushort) ( Functions.Atoi( GETBOUNDSTRING( __context__ , PARSEDMODULEMSG , "<" , ">" ) ) ) ; 
                            __context__.SourceCodeLine = 615;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMODULEMSGID > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMODULEMSGID <= Functions.GetNumArrayCols( MODULECOMM ) ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 617;
                                MODULECOMM [ RESPONSEMODULEMSGID] . ISREGISTERED = (ushort) ( 1 ) ; 
                                } 
                            
                            } 
                        
                        }
                    
                    }
                
                }
            
            }
        
        } 
    
    
    }
    
object FROM_MODULES__DOLLAR___OnChange_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 626;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 628;
            try 
                { 
                __context__.SourceCodeLine = 630;
                PARSEDMODULEMSG  .UpdateValue ( Functions.Gather ( ">" , FROM_MODULES__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 631;
                PROCESSMODULEMSG (  __context__  ) ; 
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 635;
                Print( "Issue with Module message handeling\r\n") ; 
                
                }
                
                __context__.SourceCodeLine = 626;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    

private void PROCESSDEVICEMSG (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 662;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PARSEDDEVICEMSG ) > 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 664;
        PARSEDDEVICEMSG  .UpdateValue ( Functions.Left ( PARSEDDEVICEMSG ,  (int) ( (Functions.Length( PARSEDDEVICEMSG ) - 2) ) )  ) ; 
        __context__.SourceCodeLine = 666;
        PARSEDDEVICEMSG  .UpdateValue ( REMOVEALL (  __context__ , PARSEDDEVICEMSG, "\u0000")  ) ; 
        __context__.SourceCodeLine = 668;
        if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "+OK" , PARSEDDEVICEMSG ))  ) ) 
            { 
            __context__.SourceCodeLine = 670;
            if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , ECHODEVICEMSG , GETMSG( __context__ , QUEUECOMM.SLASTMESSAGE ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 673;
                if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "HEARTBEAT" , QUEUECOMM.SLASTMESSAGE ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 675;
                    /* Trace( "HeartBeat Recieved!") */ ; 
                    __context__.SourceCodeLine = 677;
                    SETISCOMMUNICATING (  __context__  ) ; 
                    __context__.SourceCodeLine = 679;
                    GOODRESPONSE (  __context__  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 681;
                    if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "VERBOSE" , QUEUECOMM.SLASTMESSAGE ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 683;
                        IS_COMMUNICATING  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 685;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( INITIALIZE  .Value ) && Functions.TestForTrue ( Functions.BoolToInt (IS_INITIALIZED  .Value == 0) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 686;
                            INITMODULES (  __context__  ) ; 
                            }
                        
                        __context__.SourceCodeLine = 688;
                        GOODRESPONSE (  __context__  ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 692;
                        RESPONSEMSGID = (ushort) ( GETMSGID( __context__ , QUEUECOMM.SLASTMESSAGE ) ) ; 
                        __context__.SourceCodeLine = 694;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMSGID > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMSGID <= Functions.GetNumArrayRows( TO_MODULES__DOLLAR__ ) ) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 696;
                            MakeString ( TO_MODULES__DOLLAR__ [ RESPONSEMSGID] , "RESPONSE_MSG<{0}|{1}>", GETMSG (  __context__ , QUEUECOMM.SLASTMESSAGE) , PARSEDDEVICEMSG ) ; 
                            } 
                        
                        } 
                    
                    }
                
                } 
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 701;
            if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "-ERR" , PARSEDDEVICEMSG ))  ) ) 
                { 
                __context__.SourceCodeLine = 703;
                if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , ECHODEVICEMSG , GETMSG( __context__ , QUEUECOMM.SLASTMESSAGE ) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 705;
                    RESPONSEMSGID = (ushort) ( GETMSGID( __context__ , QUEUECOMM.SLASTMESSAGE ) ) ; 
                    __context__.SourceCodeLine = 707;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMSGID > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMSGID <= Functions.GetNumArrayRows( TO_MODULES__DOLLAR__ ) ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 709;
                        MakeString ( TO_MODULES__DOLLAR__ [ RESPONSEMSGID] , "RESPONSE_MSG<{0}|{1}>", GETMSG (  __context__ , QUEUECOMM.SLASTMESSAGE) , PARSEDDEVICEMSG ) ; 
                        } 
                    
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 714;
                if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "! " , PARSEDDEVICEMSG ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 716;
                    RESPONSEMSGID = (ushort) ( GETSUBSCRIBEDMSGID( __context__ , PARSEDDEVICEMSG ) ) ; 
                    __context__.SourceCodeLine = 718;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMSGID > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( RESPONSEMSGID <= Functions.GetNumArrayRows( TO_MODULES__DOLLAR__ ) ) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 720;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PARSEDDEVICEMSG ) > 235 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 722;
                            MakeString ( TO_MODULES__DOLLAR__ [ RESPONSEMSGID] , "SUBSCRIBED_MSG<") ; 
                            __context__.SourceCodeLine = 724;
                            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PARSEDDEVICEMSG ) > 0 ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 726;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PARSEDDEVICEMSG ) > 235 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 727;
                                    MakeString ( TO_MODULES__DOLLAR__ [ RESPONSEMSGID] , "{0}", Functions.Remove ( 235, PARSEDDEVICEMSG ) ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 729;
                                    MakeString ( TO_MODULES__DOLLAR__ [ RESPONSEMSGID] , "{0}", Functions.Remove ( Functions.Length( PARSEDDEVICEMSG ), PARSEDDEVICEMSG ) ) ; 
                                    }
                                
                                __context__.SourceCodeLine = 724;
                                } 
                            
                            __context__.SourceCodeLine = 732;
                            MakeString ( TO_MODULES__DOLLAR__ [ RESPONSEMSGID] , ">") ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 736;
                            MakeString ( TO_MODULES__DOLLAR__ [ RESPONSEMSGID] , "SUBSCRIBED_MSG<{0}>", PARSEDDEVICEMSG ) ; 
                            } 
                        
                        } 
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 742;
                    if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , "Welcome" , PARSEDDEVICEMSG ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 744;
                        if ( Functions.TestForTrue  ( ( IS_RS232  .Value)  ) ) 
                            {
                            __context__.SourceCodeLine = 745;
                            ENQUEUE (  __context__ , "POLL_MSG<VERBOSE|SESSION set verbose false>", (ushort)( 0 )) ; 
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 748;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PARSEDDEVICEMSG ) > 0 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 750;
                            ECHODEVICEMSG  .UpdateValue ( PARSEDDEVICEMSG  ) ; 
                            } 
                        
                        }
                    
                    }
                
                }
            
            }
        
        } 
    
    
    }
    
object FROM_DEVICE__DOLLAR___OnChange_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 759;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 761;
            try 
                { 
                __context__.SourceCodeLine = 763;
                PARSEDDEVICEMSG  .UpdateValue ( Functions.Gather ( "\u000a" , FROM_DEVICE__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 764;
                PROCESSDEVICEMSG (  __context__  ) ; 
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 768;
                Print( "Issue with Device Rx message handeling\r\n") ; 
                
                }
                
                __context__.SourceCodeLine = 759;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    

object CONNECT_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 795;
        RESET (  __context__  ) ; 
        __context__.SourceCodeLine = 796;
        CancelWait ( "QUEUEFALSERESPONSE" ) ; 
        __context__.SourceCodeLine = 798;
        CreateWait ( "STARTHEARTBEATPROCESS" , 500 , STARTHEARTBEATPROCESS_Callback ) ;
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public void STARTHEARTBEATPROCESS_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 799;
            STARTHEARTBEAT (  __context__  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

object INITIALIZE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 804;
        if ( Functions.TestForTrue  ( ( IS_COMMUNICATING  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 806;
            RESET (  __context__  ) ; 
            __context__.SourceCodeLine = 807;
            CancelWait ( "QUEUEFALSERESPONSE" ) ; 
            __context__.SourceCodeLine = 809;
            INITMODULES (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DISCONNECT_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 815;
        CancelWait ( "STARTHEARTBEATPROCESS" ) ; 
        __context__.SourceCodeLine = 817;
        RESET (  __context__  ) ; 
        __context__.SourceCodeLine = 818;
        CancelWait ( "QUEUEFALSERESPONSE" ) ; 
        __context__.SourceCodeLine = 820;
        IS_COMMUNICATING  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 821;
        STOPHEARTBEAT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object IS_RS232_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 827;
        ISRS232 = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 839;
        PARSINGDEVICEBUSY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 840;
        PARSINGMODULEBUSY = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 842;
        IS_COMMUNICATING  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 844;
        ISINITIALIZING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 845;
        ISREGISTERING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 846;
        ISHEARTBEATING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 847;
        ISRS232 = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 849;
        RESET (  __context__  ) ; 
        __context__.SourceCodeLine = 851;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 853;
        STARTREGISTRATION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    PARSEDDEVICEMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3000, this );
    ECHODEVICEMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3000, this );
    PARSEDMODULEMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    TRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
    SCOMMANDQUEUE  = new CrestronString[ 51 ];
    for( uint i = 0; i < 51; i++ )
        SCOMMANDQUEUE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    SSTATUSQUEUE  = new CrestronString[ 201 ];
    for( uint i = 0; i < 201; i++ )
        SSTATUSQUEUE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    QUEUECOMM  = new _COMMQUEUE( this, true );
    QUEUECOMM .PopulateCustomAttributeList( false );
    MODULECOMM  = new _MODULECOMM[ 101 ];
    for( uint i = 0; i < 101; i++ )
    {
        MODULECOMM [i] = new _MODULECOMM( this, true );
        MODULECOMM [i].PopulateCustomAttributeList( false );
        
    }
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    IS_RS232 = new Crestron.Logos.SplusObjects.DigitalInput( IS_RS232__DigitalInput__, this );
    m_DigitalInputList.Add( IS_RS232__DigitalInput__, IS_RS232 );
    
    CONNECT = new Crestron.Logos.SplusObjects.DigitalInput( CONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( CONNECT__DigitalInput__, CONNECT );
    
    DISCONNECT = new Crestron.Logos.SplusObjects.DigitalInput( DISCONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( DISCONNECT__DigitalInput__, DISCONNECT );
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    IS_COMMUNICATING = new Crestron.Logos.SplusObjects.DigitalOutput( IS_COMMUNICATING__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_COMMUNICATING__DigitalOutput__, IS_COMMUNICATING );
    
    TO_DEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__DOLLAR____AnalogSerialOutput__, TO_DEVICE__DOLLAR__ );
    
    TO_MODULES__DOLLAR__ = new InOutArray<StringOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        TO_MODULES__DOLLAR__[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TO_MODULES__DOLLAR____AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TO_MODULES__DOLLAR____AnalogSerialOutput__ + i, TO_MODULES__DOLLAR__[i+1] );
    }
    
    FROM_DEVICE__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( FROM_DEVICE__DOLLAR____AnalogSerialInput__, 10000, this );
    m_StringInputList.Add( FROM_DEVICE__DOLLAR____AnalogSerialInput__, FROM_DEVICE__DOLLAR__ );
    
    FROM_MODULES__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( FROM_MODULES__DOLLAR____AnalogSerialInput__, 50000, this );
    m_StringInputList.Add( FROM_MODULES__DOLLAR____AnalogSerialInput__, FROM_MODULES__DOLLAR__ );
    
    QUEUEFALSERESPONSE_Callback = new WaitFunction( QUEUEFALSERESPONSE_CallbackFn );
    HEARTBEAT_Callback = new WaitFunction( HEARTBEAT_CallbackFn );
    REGISTRATIONWAIT_Callback = new WaitFunction( REGISTRATIONWAIT_CallbackFn );
    STARTHEARTBEATPROCESS_Callback = new WaitFunction( STARTHEARTBEATPROCESS_CallbackFn );
    
    FROM_MODULES__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_MODULES__DOLLAR___OnChange_0, true ) );
    FROM_DEVICE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE__DOLLAR___OnChange_1, true ) );
    CONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONNECT_OnPush_2, false ) );
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_3, false ) );
    DISCONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISCONNECT_OnPush_4, false ) );
    IS_RS232.OnDigitalPush.Add( new InputChangeHandlerWrapper( IS_RS232_OnPush_5, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BIAMP_TESIRA_COMMAND_PROCESSOR_V1_5 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction QUEUEFALSERESPONSE_Callback;
private WaitFunction HEARTBEAT_Callback;
private WaitFunction REGISTRATIONWAIT_Callback;
private WaitFunction STARTHEARTBEATPROCESS_Callback;


const uint INITIALIZE__DigitalInput__ = 0;
const uint IS_RS232__DigitalInput__ = 1;
const uint CONNECT__DigitalInput__ = 2;
const uint DISCONNECT__DigitalInput__ = 3;
const uint FROM_DEVICE__DOLLAR____AnalogSerialInput__ = 0;
const uint FROM_MODULES__DOLLAR____AnalogSerialInput__ = 1;
const uint IS_INITIALIZED__DigitalOutput__ = 0;
const uint IS_COMMUNICATING__DigitalOutput__ = 1;
const uint TO_DEVICE__DOLLAR____AnalogSerialOutput__ = 0;
const uint TO_MODULES__DOLLAR____AnalogSerialOutput__ = 1;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}

[SplusStructAttribute(-1, true, false)]
public class _MODULECOMM : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  ISREGISTERED = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  ISINITIALIZED = 0;
    
    
    public _MODULECOMM( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class _COMMQUEUE : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  NBUSY = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  NHASITEMS = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  NCOMMANDHEAD = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  NCOMMANDTAIL = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  NSTATUSHEAD = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  NSTATUSTAIL = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  NSTRIKECOUNT = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  NRESENDLAST = 0;
    
    [SplusStructAttribute(8, false, false)]
    public CrestronString  SLASTMESSAGE;
    
    
    public _COMMQUEUE( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SLASTMESSAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, Owner );
        
        
    }
    
}

}
