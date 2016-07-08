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

namespace UserModule_PLANAR_RA_SERIES_V1_0
{
    public class UserModuleClass_PLANAR_RA_SERIES_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONNECT;
        Crestron.Logos.SplusObjects.DigitalInput DISCONNECT;
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.DigitalInput POWER_ON;
        Crestron.Logos.SplusObjects.DigitalInput POWER_OFF;
        Crestron.Logos.SplusObjects.DigitalInput POWER_TOGGLE;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_UP;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_MUTE_ON;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_MUTE_OFF;
        Crestron.Logos.SplusObjects.DigitalInput VOLUME_MUTE_TOGGLE;
        Crestron.Logos.SplusObjects.DigitalInput BACKLIGHT_UP;
        Crestron.Logos.SplusObjects.DigitalInput BACKLIGHT_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput POLL_ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput INPUT_CYCLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> INPUTS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> IR_COMMANDS;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME_SET;
        Crestron.Logos.SplusObjects.AnalogInput BACKLIGHT_SET;
        Crestron.Logos.SplusObjects.BufferInput FROM_DEVICE;
        Crestron.Logos.SplusObjects.DigitalOutput IS_COMMUNICATING;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.DigitalOutput POWER_IS_ON;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_IS_MUTED;
        Crestron.Logos.SplusObjects.DigitalOutput IS_POLLING;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> INPUTS_FB;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_LEVEL;
        Crestron.Logos.SplusObjects.AnalogOutput BACKLIGHT_LEVEL;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE;
        UShortParameter MONITOR_ID;
        UShortParameter VOLUME_STEP_SIZE;
        UShortParameter BACKLIGHT_STEP_SIZE;
        _MODULESTATUS UMODULE;
        _DEVICESTATUS UDEVICE;
        _QUEUE UQUEUE;
        CrestronString [] SCOMMANDQUEUE;
        CrestronString [] SSTATUSQUEUE;
        CrestronString [] SINPUTCOMMANDS;
        CrestronString [] SINPUTTRACKING;
        CrestronString [] SIRCOMMANDS;
        CrestronString [] SIRTRACKING;
        private ushort STARTSWITH (  SplusExecutionContext __context__, CrestronString MATCHSTRING , CrestronString SOURCESTRING ) 
            { 
            
            __context__.SourceCodeLine = 258;
            return (ushort)( Functions.BoolToInt (Functions.Find( MATCHSTRING , SOURCESTRING ) == 1)) ; 
            
            }
            
        private ushort CONTAINS (  SplusExecutionContext __context__, CrestronString MATCHSTRING , CrestronString SOURCESTRING ) 
            { 
            
            __context__.SourceCodeLine = 263;
            return (ushort)( Functions.BoolToInt ( Functions.Find( MATCHSTRING , SOURCESTRING ) > 0 )) ; 
            
            }
            
        private CrestronString GETBOUNDSTRING (  SplusExecutionContext __context__, CrestronString SOURCE , CrestronString STARTSTRING , CrestronString ENDSTRING ) 
            { 
            ushort STARTINDEX = 0;
            
            ushort ENDINDEX = 0;
            
            CrestronString RESPONSE;
            RESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 272;
            RESPONSE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 274;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOURCE ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 276;
                STARTINDEX = (ushort) ( Functions.Find( STARTSTRING , SOURCE ) ) ; 
                __context__.SourceCodeLine = 277;
                ENDINDEX = (ushort) ( Functions.Find( ENDSTRING , SOURCE , (STARTINDEX + 1) ) ) ; 
                __context__.SourceCodeLine = 279;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX < ENDINDEX ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 281;
                    STARTINDEX = (ushort) ( (STARTINDEX + Functions.Length( STARTSTRING )) ) ; 
                    __context__.SourceCodeLine = 282;
                    RESPONSE  .UpdateValue ( Functions.Mid ( SOURCE ,  (int) ( STARTINDEX ) ,  (int) ( (ENDINDEX - STARTINDEX) ) )  ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 286;
            return ( RESPONSE ) ; 
            
            }
            
        private CrestronString GETBOUNDSTRING_LAST (  SplusExecutionContext __context__, CrestronString SOURCE , CrestronString STARTSTRING , CrestronString ENDSTRING ) 
            { 
            ushort STARTINDEX = 0;
            
            ushort ENDINDEX = 0;
            
            CrestronString RESPONSE;
            RESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 295;
            RESPONSE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 297;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOURCE ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 299;
                STARTINDEX = (ushort) ( Functions.Find( STARTSTRING , SOURCE ) ) ; 
                __context__.SourceCodeLine = 300;
                ENDINDEX = (ushort) ( Functions.ReverseFind( ENDSTRING , SOURCE ) ) ; 
                __context__.SourceCodeLine = 302;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX < ENDINDEX ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 304;
                    STARTINDEX = (ushort) ( (STARTINDEX + Functions.Length( STARTSTRING )) ) ; 
                    __context__.SourceCodeLine = 305;
                    RESPONSE  .UpdateValue ( Functions.Mid ( SOURCE ,  (int) ( STARTINDEX ) ,  (int) ( (ENDINDEX - STARTINDEX) ) )  ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 309;
            return ( RESPONSE ) ; 
            
            }
            
        private ushort GETMSGDEVID (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 315;
            return (ushort)( Functions.Atoi( GETBOUNDSTRING( __context__ , MSG , "<" , "-" ) )) ; 
            
            }
            
        private CrestronString GETMSGCLASS (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 320;
            return ( GETBOUNDSTRING (  __context__ , MSG, "-", ",") ) ; 
            
            }
            
        private CrestronString GETMSGTYPE (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 325;
            return ( GETBOUNDSTRING (  __context__ , MSG, ",", "*") ) ; 
            
            }
            
        private CrestronString GETMSGSTATE (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 330;
            return ( GETBOUNDSTRING (  __context__ , MSG, "*", "|") ) ; 
            
            }
            
        private CrestronString GETMSGDATA (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            
            __context__.SourceCodeLine = 335;
            return ( GETBOUNDSTRING_LAST (  __context__ , MSG, "|", ">") ) ; 
            
            }
            
        private ushort GETSUMBYTES (  SplusExecutionContext __context__, CrestronString MSG ) 
            { 
            ushort I = 0;
            
            ushort SUM = 0;
            
            
            __context__.SourceCodeLine = 347;
            SUM = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 349;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( MSG ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 350;
                SUM = (ushort) ( (SUM ^ Byte( MSG , (int)( I ) )) ) ; 
                __context__.SourceCodeLine = 349;
                }
            
            __context__.SourceCodeLine = 352;
            return (ushort)( SUM) ; 
            
            }
            
        private CrestronString GETPROTOCOLLENGTH (  SplusExecutionContext __context__, CrestronString DATA ) 
            { 
            
            __context__.SourceCodeLine = 357;
            return ( Functions.Chr (  (int) ( ((Functions.Length( "\u0001" ) + Functions.Length( DATA )) + 1) ) ) ) ; 
            
            }
            
        private CrestronString BUILDSETMSG (  SplusExecutionContext __context__, ushort MONITORID , CrestronString COMMAND , CrestronString CONTROL ) 
            { 
            CrestronString DATA;
            DATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            CrestronString LENGTH;
            LENGTH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            CrestronString CHECKSUM;
            CHECKSUM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 367;
            MakeString ( DATA , "{0}{1}", COMMAND , CONTROL ) ; 
            __context__.SourceCodeLine = 368;
            LENGTH  .UpdateValue ( GETPROTOCOLLENGTH (  __context__ , DATA)  ) ; 
            __context__.SourceCodeLine = 370;
            MakeString ( MSG , "{0}{1}", MSG , "\u00A6" ) ; 
            __context__.SourceCodeLine = 371;
            MakeString ( MSG , "{0}{1}", MSG , Functions.Chr (  (int) ( MONITORID ) ) ) ; 
            __context__.SourceCodeLine = 372;
            MakeString ( MSG , "{0}{1}", MSG , "\u0000" ) ; 
            __context__.SourceCodeLine = 373;
            MakeString ( MSG , "{0}{1}", MSG , "\u0000" ) ; 
            __context__.SourceCodeLine = 374;
            MakeString ( MSG , "{0}{1}", MSG , "\u0000" ) ; 
            __context__.SourceCodeLine = 375;
            MakeString ( MSG , "{0}{1}", MSG , LENGTH ) ; 
            __context__.SourceCodeLine = 376;
            MakeString ( MSG , "{0}{1}", MSG , "\u0001" ) ; 
            __context__.SourceCodeLine = 377;
            MakeString ( MSG , "{0}{1}", MSG , COMMAND ) ; 
            __context__.SourceCodeLine = 378;
            MakeString ( MSG , "{0}{1}", MSG , CONTROL ) ; 
            __context__.SourceCodeLine = 380;
            CHECKSUM  .UpdateValue ( Functions.Chr (  (int) ( GETSUMBYTES( __context__ , MSG ) ) )  ) ; 
            __context__.SourceCodeLine = 382;
            MakeString ( MSG , "{0}{1}", MSG , CHECKSUM ) ; 
            __context__.SourceCodeLine = 384;
            return ( MSG ) ; 
            
            }
            
        private CrestronString BUILDGETMSG (  SplusExecutionContext __context__, ushort MONITORID , CrestronString COMMAND ) 
            { 
            CrestronString LENGTH;
            LENGTH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            CrestronString CHECKSUM;
            CHECKSUM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 393;
            LENGTH  .UpdateValue ( GETPROTOCOLLENGTH (  __context__ , COMMAND)  ) ; 
            __context__.SourceCodeLine = 395;
            MakeString ( MSG , "{0}{1}", MSG , "\u00A6" ) ; 
            __context__.SourceCodeLine = 396;
            MakeString ( MSG , "{0}{1}", MSG , Functions.Chr (  (int) ( MONITORID ) ) ) ; 
            __context__.SourceCodeLine = 397;
            MakeString ( MSG , "{0}{1}", MSG , "\u0000" ) ; 
            __context__.SourceCodeLine = 398;
            MakeString ( MSG , "{0}{1}", MSG , "\u0000" ) ; 
            __context__.SourceCodeLine = 399;
            MakeString ( MSG , "{0}{1}", MSG , "\u0000" ) ; 
            __context__.SourceCodeLine = 400;
            MakeString ( MSG , "{0}{1}", MSG , LENGTH ) ; 
            __context__.SourceCodeLine = 401;
            MakeString ( MSG , "{0}{1}", MSG , "\u0001" ) ; 
            __context__.SourceCodeLine = 402;
            MakeString ( MSG , "{0}{1}", MSG , COMMAND ) ; 
            __context__.SourceCodeLine = 404;
            CHECKSUM  .UpdateValue ( Functions.Chr (  (int) ( GETSUMBYTES( __context__ , MSG ) ) )  ) ; 
            __context__.SourceCodeLine = 406;
            MakeString ( MSG , "{0}{1}", MSG , CHECKSUM ) ; 
            __context__.SourceCodeLine = 408;
            return ( MSG ) ; 
            
            }
            
        private CrestronString BUILDTRACKINGHEADER (  SplusExecutionContext __context__, ushort DEVICEID , CrestronString MSGCLASS , CrestronString MSGTYPE , CrestronString MSGSTATE ) 
            { 
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 415;
            MakeString ( MSG , "{0:d}-{1},{2}*{3}", (ushort)DEVICEID, MSGCLASS , MSGTYPE , MSGSTATE ) ; 
            __context__.SourceCodeLine = 417;
            return ( MSG ) ; 
            
            }
            
        private void RESETQUEUE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 426;
            UQUEUE . NBUSY = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 427;
            UQUEUE . NHASITEMS = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 428;
            UQUEUE . NCOMMANDHEAD = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 429;
            UQUEUE . NCOMMANDTAIL = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 430;
            UQUEUE . NSTATUSHEAD = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 431;
            UQUEUE . NSTATUSTAIL = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 432;
            UQUEUE . NSTRIKECOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 433;
            UQUEUE . SLASTMSGOUT  .UpdateValue ( ""  ) ; 
            
            }
            
        private void RESETMODULE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 438;
            UMODULE . NISCOMMUNICATING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 439;
            UMODULE . NISINITIALIZING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 440;
            UMODULE . NISINITIALIZED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 441;
            UMODULE . NISPARSING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 442;
            UMODULE . NISPOLLING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 443;
            UMODULE . SLASTMSGIN  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 445;
            IS_COMMUNICATING  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 446;
            IS_INITIALIZED  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RESETDEVICE (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 453;
            UDEVICE . NPOWER = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 454;
            UDEVICE . NINPUT = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 455;
            UDEVICE . NVOLUMELEVEL = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 456;
            UDEVICE . NLASTVOLUMELEVEL = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 457;
            UDEVICE . NVOLUMEMUTE = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 458;
            UDEVICE . NBACKLIGHTLEVEL = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 460;
            POWER_IS_ON  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 461;
            VOLUME_IS_MUTED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 462;
            VOLUME_LEVEL  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 463;
            BACKLIGHT_LEVEL  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 465;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)8; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 466;
                INPUTS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 465;
                }
            
            
            }
            
        private void RESET (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 471;
            /* Trace( "reset") */ ; 
            __context__.SourceCodeLine = 473;
            RESETQUEUE (  __context__  ) ; 
            __context__.SourceCodeLine = 474;
            RESETMODULE (  __context__  ) ; 
            __context__.SourceCodeLine = 475;
            RESETDEVICE (  __context__  ) ; 
            
            }
            
        private ushort ISQUEUEEMPTY (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 484;
            return (ushort)( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NHASITEMS == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NBUSY == 0) )) )) ; 
            
            }
            
        private CrestronString DEQUEUE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SCMD;
            SCMD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 491;
            SCMD  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 493;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NHASITEMS == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NBUSY == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 495;
                UQUEUE . NBUSY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 498;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDHEAD != UQUEUE.NCOMMANDTAIL))  ) ) 
                    { 
                    __context__.SourceCodeLine = 500;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDTAIL == Functions.GetNumArrayRows( SCOMMANDQUEUE )))  ) ) 
                        {
                        __context__.SourceCodeLine = 501;
                        UQUEUE . NCOMMANDTAIL = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 503;
                        UQUEUE . NCOMMANDTAIL = (ushort) ( (UQUEUE.NCOMMANDTAIL + 1) ) ; 
                        }
                    
                    __context__.SourceCodeLine = 505;
                    UQUEUE . SLASTMSGOUT  .UpdateValue ( SCOMMANDQUEUE [ UQUEUE.NCOMMANDTAIL ]  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 508;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSHEAD != UQUEUE.NSTATUSTAIL))  ) ) 
                        { 
                        __context__.SourceCodeLine = 510;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSTAIL == Functions.GetNumArrayRows( SSTATUSQUEUE )))  ) ) 
                            {
                            __context__.SourceCodeLine = 511;
                            UQUEUE . NSTATUSTAIL = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 513;
                            UQUEUE . NSTATUSTAIL = (ushort) ( (UQUEUE.NSTATUSTAIL + 1) ) ; 
                            }
                        
                        __context__.SourceCodeLine = 515;
                        UQUEUE . SLASTMSGOUT  .UpdateValue ( SSTATUSQUEUE [ UQUEUE.NSTATUSTAIL ]  ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 518;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NCOMMANDHEAD == UQUEUE.NCOMMANDTAIL) ) && Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NSTATUSHEAD == UQUEUE.NSTATUSTAIL) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 519;
                    UQUEUE . NHASITEMS = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 521;
                SCMD  .UpdateValue ( GETMSGDATA (  __context__ , UQUEUE.SLASTMSGOUT)  ) ; 
                } 
            
            __context__.SourceCodeLine = 524;
            return ( SCMD ) ; 
            
            }
            
        private void SENDNEXTQUEUEITEM (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SOUTGOING;
            SOUTGOING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 531;
            SOUTGOING  .UpdateValue ( DEQUEUE (  __context__  )  ) ; 
            __context__.SourceCodeLine = 533;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOUTGOING ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 535;
                /* Trace( "sendNextQueueItem() - sending next message") */ ; 
                __context__.SourceCodeLine = 537;
                MakeString ( TO_DEVICE , "{0}\u000D", SOUTGOING ) ; 
                __context__.SourceCodeLine = 539;
                CreateWait ( "QUEUEFALSERESPONSE" , 250 , QUEUEFALSERESPONSE_Callback ) ;
                } 
            
            else 
                {
                __context__.SourceCodeLine = 559;
                /* Trace( "sendNextQueueItem() - nothing to send") */ ; 
                }
            
            
            }
            
        public void QUEUEFALSERESPONSE_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 541;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NBUSY == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 543;
                UQUEUE . NBUSY = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 545;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UQUEUE.NSTRIKECOUNT < 3 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 547;
                    UQUEUE . NSTRIKECOUNT = (ushort) ( (UQUEUE.NSTRIKECOUNT + 1) ) ; 
                    __context__.SourceCodeLine = 549;
                    /* Trace( "Failed Response[{0}]", UQUEUE . SLASTMSGOUT ) */ ; 
                    __context__.SourceCodeLine = 550;
                    /* Trace( "nStrikeCount[{0:d}]", (ushort)UQUEUE.NSTRIKECOUNT) */ ; 
                    __context__.SourceCodeLine = 551;
                    SENDNEXTQUEUEITEM (  __context__  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 554;
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
        
        
        __context__.SourceCodeLine = 566;
        NQUEUEWASEMPTY = (ushort) ( ISQUEUEEMPTY( __context__ ) ) ; 
        __context__.SourceCodeLine = 568;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BPRIORITY == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 570;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDHEAD == Functions.GetNumArrayRows( SCOMMANDQUEUE )))  ) ) 
                { 
                __context__.SourceCodeLine = 572;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDTAIL != 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 574;
                    UQUEUE . NCOMMANDHEAD = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 575;
                    SCOMMANDQUEUE [ UQUEUE.NCOMMANDHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 576;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 579;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDTAIL != (UQUEUE.NCOMMANDHEAD + 1)))  ) ) 
                    { 
                    __context__.SourceCodeLine = 581;
                    UQUEUE . NCOMMANDHEAD = (ushort) ( (UQUEUE.NCOMMANDHEAD + 1) ) ; 
                    __context__.SourceCodeLine = 582;
                    SCOMMANDQUEUE [ UQUEUE.NCOMMANDHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 583;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                }
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 588;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSHEAD == Functions.GetNumArrayRows( SSTATUSQUEUE )))  ) ) 
                { 
                __context__.SourceCodeLine = 590;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSTAIL != 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 592;
                    UQUEUE . NSTATUSHEAD = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 593;
                    SSTATUSQUEUE [ UQUEUE.NSTATUSHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 594;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 597;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSTAIL != (UQUEUE.NSTATUSHEAD + 1)))  ) ) 
                    { 
                    __context__.SourceCodeLine = 599;
                    UQUEUE . NSTATUSHEAD = (ushort) ( (UQUEUE.NSTATUSHEAD + 1) ) ; 
                    __context__.SourceCodeLine = 600;
                    SSTATUSQUEUE [ UQUEUE.NSTATUSHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 601;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                }
            
            } 
        
        __context__.SourceCodeLine = 605;
        if ( Functions.TestForTrue  ( ( NQUEUEWASEMPTY)  ) ) 
            {
            __context__.SourceCodeLine = 606;
            SENDNEXTQUEUEITEM (  __context__  ) ; 
            }
        
        
        }
        
    private void SETPOWER (  SplusExecutionContext __context__, ushort MONITORID , ushort STATE ) 
        { 
        CrestronString STRACKINGHEADER;
        STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SSETMSG;
        SSETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 619;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 621;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (STATE == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 623;
                STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "POWER", "SET", "ON")  ) ; 
                __context__.SourceCodeLine = 624;
                SSETMSG  .UpdateValue ( BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "\u00A3", "\u0002")  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 628;
                STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "POWER", "SET", "OFF")  ) ; 
                __context__.SourceCodeLine = 629;
                SSETMSG  .UpdateValue ( BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "\u00A3", "\u0001")  ) ; 
                } 
            
            __context__.SourceCodeLine = 632;
            MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SSETMSG ) ; 
            __context__.SourceCodeLine = 633;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
            } 
        
        
        }
        
    private void GETPOWER (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString STRACKINGHEADER;
        STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SGETMSG;
        SGETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 643;
        STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "POWER", "GET", "")  ) ; 
        __context__.SourceCodeLine = 644;
        SGETMSG  .UpdateValue ( BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "\u00A4")  ) ; 
        __context__.SourceCodeLine = 646;
        MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SGETMSG ) ; 
        __context__.SourceCodeLine = 647;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETINPUT (  SplusExecutionContext __context__, ushort MONITORID , ushort INPUT ) 
        { 
        CrestronString STRACKINGHEADER;
        STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SSETMSG;
        SSETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 656;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 658;
            STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "INPUT", "SET", SINPUTTRACKING[ INPUT ])  ) ; 
            __context__.SourceCodeLine = 659;
            SSETMSG  .UpdateValue ( BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "\u00A5", SINPUTCOMMANDS[ INPUT ])  ) ; 
            __context__.SourceCodeLine = 661;
            MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SSETMSG ) ; 
            __context__.SourceCodeLine = 662;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
            } 
        
        
        }
        
    private void GETINPUT (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString STRACKINGHEADER;
        STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SGETMSG;
        SGETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 672;
        STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "INPUT", "GET", "")  ) ; 
        __context__.SourceCodeLine = 673;
        SGETMSG  .UpdateValue ( BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "\u00A6")  ) ; 
        __context__.SourceCodeLine = 675;
        MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SGETMSG ) ; 
        __context__.SourceCodeLine = 676;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SENDIR (  SplusExecutionContext __context__, ushort MONITORID , ushort IRFUNCTION ) 
        { 
        CrestronString STRACKINGHEADER;
        STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SSETMSG;
        SSETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 685;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 687;
            STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "IR", "SET", SIRTRACKING[ IRFUNCTION ])  ) ; 
            __context__.SourceCodeLine = 688;
            SSETMSG  .UpdateValue ( BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "\u00DB", SIRCOMMANDS[ IRFUNCTION ])  ) ; 
            __context__.SourceCodeLine = 690;
            MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SSETMSG ) ; 
            __context__.SourceCodeLine = 691;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
            } 
        
        
        }
        
    private void SETVOLUME (  SplusExecutionContext __context__, ushort MONITORID , ushort LEVEL ) 
        { 
        CrestronString STRACKINGHEADER;
        STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SSETMSG;
        SSETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 701;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 703;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( LEVEL >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( LEVEL <= 60 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 705;
                STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "VOLUME", "SET", Functions.ItoA( (int)( LEVEL ) ))  ) ; 
                __context__.SourceCodeLine = 706;
                SSETMSG  .UpdateValue ( BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "\u00AC", Functions.Chr( (int)( LEVEL ) ))  ) ; 
                __context__.SourceCodeLine = 708;
                MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SSETMSG ) ; 
                __context__.SourceCodeLine = 709;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETVOLUME (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString STRACKINGHEADER;
        STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SGETMSG;
        SGETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 720;
        STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "VOLUME", "GET", "")  ) ; 
        __context__.SourceCodeLine = 721;
        SGETMSG  .UpdateValue ( BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "\u00AD")  ) ; 
        __context__.SourceCodeLine = 723;
        MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SGETMSG ) ; 
        __context__.SourceCodeLine = 724;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETBACKLIGHT (  SplusExecutionContext __context__, ushort MONITORID , ushort LEVEL ) 
        { 
        CrestronString STRACKINGHEADER;
        STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SSETMSG;
        SSETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 733;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 735;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( LEVEL >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( LEVEL <= 100 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 737;
                STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "BACKLIGHT", "SET", Functions.ItoA( (int)( LEVEL ) ))  ) ; 
                __context__.SourceCodeLine = 738;
                SSETMSG  .UpdateValue ( BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "\u0003", Functions.Chr( (int)( LEVEL ) ))  ) ; 
                __context__.SourceCodeLine = 740;
                MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SSETMSG ) ; 
                __context__.SourceCodeLine = 741;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETBACKLIGHT (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString STRACKINGHEADER;
        STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SGETMSG;
        SGETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 752;
        STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITORID ), "BACKLIGHT", "GET", "")  ) ; 
        __context__.SourceCodeLine = 753;
        SGETMSG  .UpdateValue ( BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "\u0004")  ) ; 
        __context__.SourceCodeLine = 755;
        MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SGETMSG ) ; 
        __context__.SourceCodeLine = 756;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void GETCURRENTSTATUSALL (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 765;
        GETPOWER (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        __context__.SourceCodeLine = 766;
        GETINPUT (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        __context__.SourceCodeLine = 767;
        GETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        __context__.SourceCodeLine = 768;
        GETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        
        }
        
    private void SENDPOLL (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 773;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 775;
            /* Trace( "sendPoll()") */ ; 
            __context__.SourceCodeLine = 777;
            GETCURRENTSTATUSALL (  __context__  ) ; 
            __context__.SourceCodeLine = 779;
            CreateWait ( "POLL" , 2000 , POLL_Callback ) ;
            } 
        
        
        }
        
    public void POLL_CallbackFn( object stateInfo )
    {
    
        try
        {
            Wait __LocalWait__ = (Wait)stateInfo;
            SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
            __LocalWait__.RemoveFromList();
            
            {
            __context__.SourceCodeLine = 780;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 1))  ) ) 
                {
                __context__.SourceCodeLine = 781;
                SENDPOLL (  __context__  ) ; 
                }
            
            }
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void STARTPOLL (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 787;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 789;
        UMODULE . NISPOLLING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 790;
        IS_POLLING  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 791;
        SENDPOLL (  __context__  ) ; 
        } 
    
    
    }
    
private void STOPPOLL (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 797;
    UMODULE . NISPOLLING = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 798;
    IS_POLLING  .Value = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 799;
    CancelWait ( "POLL" ) ; 
    
    }
    
private ushort ISINITIALIZED (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 808;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 65535) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NINPUT == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NVOLUMELEVEL == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NBACKLIGHTLEVEL == 65535) )) ))  ) ) 
        {
        __context__.SourceCodeLine = 809;
        return (ushort)( 0) ; 
        }
    
    __context__.SourceCodeLine = 811;
    return (ushort)( 1) ; 
    
    }
    
private void GETINITIALIZED (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 816;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISINITIALIZING == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (ISINITIALIZED( __context__ ) == 0) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 818;
        /* Trace( "getInitialized()") */ ; 
        __context__.SourceCodeLine = 820;
        UMODULE . NISINITIALIZING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 821;
        GETCURRENTSTATUSALL (  __context__  ) ; 
        } 
    
    
    }
    
private void GOODRESPONSE (  SplusExecutionContext __context__ ) 
    { 
    CrestronString SCLASS;
    SCLASS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    
    __context__.SourceCodeLine = 833;
    /* Trace( "goodResponse()") */ ; 
    __context__.SourceCodeLine = 835;
    UMODULE . NISCOMMUNICATING = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 836;
    IS_COMMUNICATING  .Value = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 838;
    UQUEUE . NSTRIKECOUNT = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 840;
    SCLASS  .UpdateValue ( GETMSGCLASS (  __context__ , UQUEUE.SLASTMSGOUT)  ) ; 
    __context__.SourceCodeLine = 842;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (SCLASS == "HEARTBEAT") ) && Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISINITIALIZING == 0) )) ))  ) ) 
        {
        __context__.SourceCodeLine = 843;
        GETINITIALIZED (  __context__  ) ; 
        }
    
    __context__.SourceCodeLine = 845;
    UQUEUE . NBUSY = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 847;
    SENDNEXTQUEUEITEM (  __context__  ) ; 
    
    }
    
private void PROCESSDEVICEMSG (  SplusExecutionContext __context__ ) 
    { 
    ushort I = 0;
    
    ushort DEVICEID = 0;
    
    CrestronString MSGCLASS;
    MSGCLASS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    CrestronString MSGTYPE;
    MSGTYPE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    CrestronString MSGSTATE;
    MSGSTATE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    ushort VOLUMELVLIN = 0;
    
    ushort BACKLIGHTLVLIN = 0;
    
    
    __context__.SourceCodeLine = 860;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( UMODULE.SLASTMSGIN ) > 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 862;
        MSGTYPE  .UpdateValue ( GETMSGTYPE (  __context__ , UQUEUE.SLASTMSGOUT)  ) ; 
        __context__.SourceCodeLine = 864;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGTYPE == "GET"))  ) ) 
            { 
            __context__.SourceCodeLine = 866;
            DEVICEID = (ushort) ( Byte( UMODULE.SLASTMSGIN , (int)( 2 ) ) ) ; 
            __context__.SourceCodeLine = 867;
            MSGCLASS  .UpdateValue ( Functions.Chr (  (int) ( Byte( UMODULE.SLASTMSGIN , (int)( 7 ) ) ) )  ) ; 
            __context__.SourceCodeLine = 868;
            MSGSTATE  .UpdateValue ( Functions.Chr (  (int) ( Byte( UMODULE.SLASTMSGIN , (int)( (7 + 1) ) ) ) )  ) ; 
            __context__.SourceCodeLine = 870;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGCLASS == "\u008D"))  ) ) 
                {
                __context__.SourceCodeLine = 871;
                /* Trace( "got response to heartbeat") */ ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 872;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGCLASS == "\u00A4"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 874;
                    /* Trace( "got response to power query") */ ; 
                    __context__.SourceCodeLine = 876;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGSTATE == "\u0002"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 878;
                        UDEVICE . NPOWER = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 879;
                        POWER_IS_ON  .Value = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 881;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGSTATE == "\u0001"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 883;
                            UDEVICE . NPOWER = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 884;
                            POWER_IS_ON  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 887;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGCLASS == "\u00A6"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 889;
                        /* Trace( "got response to input query") */ ; 
                        __context__.SourceCodeLine = 891;
                        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                        ushort __FN_FOREND_VAL__1 = (ushort)8; 
                        int __FN_FORSTEP_VAL__1 = (int)1; 
                        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                            { 
                            __context__.SourceCodeLine = 893;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGSTATE == SINPUTCOMMANDS[ I ]))  ) ) 
                                { 
                                __context__.SourceCodeLine = 895;
                                UDEVICE . NINPUT = (ushort) ( I ) ; 
                                __context__.SourceCodeLine = 896;
                                INPUTS_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 900;
                                INPUTS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 891;
                            } 
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 904;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGCLASS == "\u00AD"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 906;
                            /* Trace( "got response to volume query") */ ; 
                            __context__.SourceCodeLine = 908;
                            VOLUMELVLIN = (ushort) ( Byte( MSGSTATE , (int)( 1 ) ) ) ; 
                            __context__.SourceCodeLine = 910;
                            UDEVICE . NVOLUMELEVEL = (ushort) ( VOLUMELVLIN ) ; 
                            __context__.SourceCodeLine = 911;
                            VOLUME_LEVEL  .Value = (ushort) ( VOLUMELVLIN ) ; 
                            __context__.SourceCodeLine = 913;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VOLUMELVLIN == 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 915;
                                UDEVICE . NVOLUMEMUTE = (ushort) ( 1 ) ; 
                                __context__.SourceCodeLine = 916;
                                VOLUME_IS_MUTED  .Value = (ushort) ( 1 ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 920;
                                UDEVICE . NLASTVOLUMELEVEL = (ushort) ( VOLUMELVLIN ) ; 
                                __context__.SourceCodeLine = 921;
                                UDEVICE . NVOLUMEMUTE = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 922;
                                VOLUME_IS_MUTED  .Value = (ushort) ( 0 ) ; 
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 925;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGCLASS == "\u0004"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 927;
                                /* Trace( "got response to backlight query") */ ; 
                                __context__.SourceCodeLine = 929;
                                BACKLIGHTLVLIN = (ushort) ( Byte( MSGSTATE , (int)( 1 ) ) ) ; 
                                __context__.SourceCodeLine = 931;
                                UDEVICE . NBACKLIGHTLEVEL = (ushort) ( BACKLIGHTLVLIN ) ; 
                                __context__.SourceCodeLine = 932;
                                BACKLIGHT_LEVEL  .Value = (ushort) ( BACKLIGHTLVLIN ) ; 
                                } 
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            } 
        
        else 
            {
            __context__.SourceCodeLine = 935;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGTYPE == "SET"))  ) ) 
                { 
                __context__.SourceCodeLine = 937;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Chr( (int)( Byte( UMODULE.SLASTMSGIN , (int)( 8 ) ) ) ) == "\u0000"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 939;
                    /* Trace( "got ACK response to set") */ ; 
                    __context__.SourceCodeLine = 941;
                    DEVICEID = (ushort) ( GETMSGDEVID( __context__ , UQUEUE.SLASTMSGOUT ) ) ; 
                    __context__.SourceCodeLine = 942;
                    MSGCLASS  .UpdateValue ( GETMSGCLASS (  __context__ , UQUEUE.SLASTMSGOUT)  ) ; 
                    __context__.SourceCodeLine = 943;
                    MSGSTATE  .UpdateValue ( GETMSGSTATE (  __context__ , UQUEUE.SLASTMSGOUT)  ) ; 
                    __context__.SourceCodeLine = 945;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGCLASS == "POWER"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 947;
                        /* Trace( "got response to power command") */ ; 
                        __context__.SourceCodeLine = 949;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGSTATE == "ON"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 951;
                            UDEVICE . NPOWER = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 952;
                            POWER_IS_ON  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 954;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGSTATE == "OFF"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 956;
                                UDEVICE . NPOWER = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 957;
                                POWER_IS_ON  .Value = (ushort) ( 0 ) ; 
                                } 
                            
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 960;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGCLASS == "INPUT"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 962;
                            /* Trace( "got response to input command") */ ; 
                            __context__.SourceCodeLine = 964;
                            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                            ushort __FN_FOREND_VAL__2 = (ushort)8; 
                            int __FN_FORSTEP_VAL__2 = (int)1; 
                            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                { 
                                __context__.SourceCodeLine = 966;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGSTATE == SINPUTTRACKING[ I ]))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 968;
                                    UDEVICE . NINPUT = (ushort) ( I ) ; 
                                    __context__.SourceCodeLine = 969;
                                    INPUTS_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 973;
                                    INPUTS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                    } 
                                
                                __context__.SourceCodeLine = 964;
                                } 
                            
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 978;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGCLASS == "VOLUME"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 980;
                                /* Trace( "got response to volume command") */ ; 
                                __context__.SourceCodeLine = 982;
                                VOLUMELVLIN = (ushort) ( Functions.Atoi( MSGSTATE ) ) ; 
                                __context__.SourceCodeLine = 984;
                                UDEVICE . NVOLUMELEVEL = (ushort) ( VOLUMELVLIN ) ; 
                                __context__.SourceCodeLine = 985;
                                VOLUME_LEVEL  .Value = (ushort) ( VOLUMELVLIN ) ; 
                                __context__.SourceCodeLine = 987;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (VOLUMELVLIN == 0))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 989;
                                    UDEVICE . NVOLUMEMUTE = (ushort) ( 1 ) ; 
                                    __context__.SourceCodeLine = 990;
                                    VOLUME_IS_MUTED  .Value = (ushort) ( 1 ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 994;
                                    UDEVICE . NLASTVOLUMELEVEL = (ushort) ( VOLUMELVLIN ) ; 
                                    __context__.SourceCodeLine = 995;
                                    UDEVICE . NVOLUMEMUTE = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 996;
                                    VOLUME_IS_MUTED  .Value = (ushort) ( 0 ) ; 
                                    } 
                                
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 999;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MSGCLASS == "BACKLIGHT"))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1001;
                                    /* Trace( "got response to backlight command") */ ; 
                                    __context__.SourceCodeLine = 1003;
                                    BACKLIGHTLVLIN = (ushort) ( Functions.Atoi( MSGSTATE ) ) ; 
                                    __context__.SourceCodeLine = 1005;
                                    UDEVICE . NBACKLIGHTLEVEL = (ushort) ( BACKLIGHTLVLIN ) ; 
                                    __context__.SourceCodeLine = 1006;
                                    BACKLIGHT_LEVEL  .Value = (ushort) ( BACKLIGHTLVLIN ) ; 
                                    } 
                                
                                }
                            
                            }
                        
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1010;
                    /* Trace( "got NACK or NAV response to set") */ ; 
                    }
                
                } 
            
            }
        
        __context__.SourceCodeLine = 1013;
        CancelWait ( "QUEUEFALSERESPONSE" ) ; 
        __context__.SourceCodeLine = 1014;
        GOODRESPONSE (  __context__  ) ; 
        __context__.SourceCodeLine = 1016;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISINITIALIZING == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (ISINITIALIZED( __context__ ) == 1) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1018;
            /* Trace( "initialization complete") */ ; 
            __context__.SourceCodeLine = 1020;
            UMODULE . NISINITIALIZING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 1021;
            UMODULE . NISINITIALIZED = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1022;
            IS_INITIALIZED  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 1024;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (POLL_ENABLE  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISPOLLING == 0) )) ))  ) ) 
                {
                __context__.SourceCodeLine = 1025;
                CreateWait ( "STARTPOLLINGPROCESS" , 2000 , STARTPOLLINGPROCESS_Callback ) ;
                }
            
            } 
        
        } 
    
    
    }
    
public void STARTPOLLINGPROCESS_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 1026;
            STARTPOLL (  __context__  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void SENDHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    CrestronString STRACKINGHEADER;
    STRACKINGHEADER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    CrestronString SGETMSG;
    SGETMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    CrestronString SCOMMAND;
    SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    
    __context__.SourceCodeLine = 1041;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISHEARTBEATING == 1))  ) ) 
        { 
        __context__.SourceCodeLine = 1043;
        if ( Functions.TestForTrue  ( ( ISQUEUEEMPTY( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 1045;
            /* Trace( "sendHeartbeat()") */ ; 
            __context__.SourceCodeLine = 1047;
            STRACKINGHEADER  .UpdateValue ( BUILDTRACKINGHEADER (  __context__ , (ushort)( MONITOR_ID  .Value ), "HEARTBEAT", "GET", "")  ) ; 
            __context__.SourceCodeLine = 1048;
            SGETMSG  .UpdateValue ( BUILDGETMSG (  __context__ , (ushort)( MONITOR_ID  .Value ), "\u008D")  ) ; 
            __context__.SourceCodeLine = 1050;
            MakeString ( SCOMMAND , "<{0}|{1}>", STRACKINGHEADER , SGETMSG ) ; 
            __context__.SourceCodeLine = 1051;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
            } 
        
        __context__.SourceCodeLine = 1054;
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
        
            {
            __context__.SourceCodeLine = 1055;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISHEARTBEATING == 1))  ) ) 
                {
                __context__.SourceCodeLine = 1056;
                SENDHEARTBEAT (  __context__  ) ; 
                }
            
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void STARTHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1062;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISHEARTBEATING == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 1064;
        UMODULE . NISHEARTBEATING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1065;
        SENDHEARTBEAT (  __context__  ) ; 
        } 
    
    
    }
    
private void STOPHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1071;
    UMODULE . NISHEARTBEATING = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 1072;
    CancelWait ( "HEARTBEAT" ) ; 
    
    }
    
private void DOCONNECT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1081;
    /* Trace( "doConnect()") */ ; 
    __context__.SourceCodeLine = 1083;
    RESET (  __context__  ) ; 
    __context__.SourceCodeLine = 1084;
    CancelWait ( "QUEUEFALSERESPONSE" ) ; 
    __context__.SourceCodeLine = 1086;
    CreateWait ( "STARTHEARTBEATPROCESS" , 500 , STARTHEARTBEATPROCESS_Callback ) ;
    
    }
    
public void STARTHEARTBEATPROCESS_CallbackFn( object stateInfo )
{

    try
    {
        Wait __LocalWait__ = (Wait)stateInfo;
        SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
        __LocalWait__.RemoveFromList();
        
            {
            __context__.SourceCodeLine = 1087;
            STARTHEARTBEAT (  __context__  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void DODISCONNECT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1092;
    /* Trace( "doDisconnect()") */ ; 
    __context__.SourceCodeLine = 1094;
    RESET (  __context__  ) ; 
    __context__.SourceCodeLine = 1095;
    CancelWait ( "STARTHEARTBEATPROCESS" ) ; 
    __context__.SourceCodeLine = 1096;
    CancelWait ( "STARTPOLLINGPROCESS" ) ; 
    __context__.SourceCodeLine = 1097;
    CancelWait ( "QUEUEFALSERESPONSE" ) ; 
    __context__.SourceCodeLine = 1098;
    STOPHEARTBEAT (  __context__  ) ; 
    __context__.SourceCodeLine = 1099;
    STOPPOLL (  __context__  ) ; 
    
    }
    
private void DOREINITIALIZE (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1104;
    /* Trace( "doReinitialize()") */ ; 
    __context__.SourceCodeLine = 1106;
    DODISCONNECT (  __context__  ) ; 
    __context__.SourceCodeLine = 1107;
    DOCONNECT (  __context__  ) ; 
    
    }
    
object CONNECT_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1117;
        DOCONNECT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DISCONNECT_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1122;
        DODISCONNECT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INITIALIZE_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1127;
        DOREINITIALIZE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POWER_ON_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1132;
        SETPOWER (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POWER_OFF_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1137;
        SETPOWER (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POWER_TOGGLE_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1142;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NPOWER == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1143;
            SETPOWER (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1144;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NPOWER == 0))  ) ) 
                {
                __context__.SourceCodeLine = 1145;
                SETPOWER (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 1 )) ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUTS_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INPUT = 0;
        
        
        __context__.SourceCodeLine = 1151;
        INPUT = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1153;
        SETINPUT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( INPUT )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUT_CYCLE_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1158;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NINPUT == 8))  ) ) 
            {
            __context__.SourceCodeLine = 1159;
            SETINPUT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 1 )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1161;
            SETINPUT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NINPUT + 1) )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_UP_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1166;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NVOLUMELEVEL < 60 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1168;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (60 - UDEVICE.NVOLUMELEVEL) > VOLUME_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1169;
                SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NVOLUMELEVEL + VOLUME_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1171;
                SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 60 )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_DOWN_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1177;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NVOLUMELEVEL > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1179;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (UDEVICE.NVOLUMELEVEL - 0) > VOLUME_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1180;
                SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NVOLUMELEVEL - VOLUME_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1182;
                SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_MUTE_ON_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1188;
        SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_MUTE_OFF_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1193;
        SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( UDEVICE.NLASTVOLUMELEVEL )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_MUTE_TOGGLE_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1198;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NVOLUMEMUTE == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1199;
            SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( UDEVICE.NLASTVOLUMELEVEL )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1200;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NVOLUMEMUTE == 0))  ) ) 
                {
                __context__.SourceCodeLine = 1201;
                SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_SET_OnChange_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1206;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VOLUME_SET  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VOLUME_SET  .UshortValue <= 60 ) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1207;
            SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( VOLUME_SET  .UshortValue )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACKLIGHT_UP_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1212;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NBACKLIGHTLEVEL < 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1214;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (100 - UDEVICE.NBACKLIGHTLEVEL) > BACKLIGHT_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1215;
                SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NBACKLIGHTLEVEL + BACKLIGHT_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1217;
                SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 100 )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACKLIGHT_DOWN_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1223;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NBACKLIGHTLEVEL > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1225;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (UDEVICE.NBACKLIGHTLEVEL - 0) > BACKLIGHT_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1226;
                SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NBACKLIGHTLEVEL - BACKLIGHT_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1228;
                SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACKLIGHT_SET_OnChange_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1234;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( BACKLIGHT_SET  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( BACKLIGHT_SET  .UshortValue <= 100 ) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1235;
            SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( BACKLIGHT_SET  .UshortValue )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object IR_COMMANDS_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IRFUNCTION = 0;
        
        
        __context__.SourceCodeLine = 1241;
        IRFUNCTION = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1243;
        SENDIR (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( IRFUNCTION )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_ENABLE_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1248;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 0))  ) ) 
            {
            __context__.SourceCodeLine = 1249;
            STARTPOLL (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_ENABLE_OnRelease_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1254;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1255;
            STOPPOLL (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_DEVICE_OnChange_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString MSGTOLENGTH;
        MSGTOLENGTH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString MSGREMAINDER;
        MSGREMAINDER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString DELIM;
        DELIM  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        ushort DELIMINDEX = 0;
        
        
        __context__.SourceCodeLine = 1266;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 1268;
            try 
                { 
                __context__.SourceCodeLine = 1270;
                MSGTOLENGTH  .UpdateValue ( Functions.Gather ( 5, FROM_DEVICE )  ) ; 
                __context__.SourceCodeLine = 1272;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Chr( (int)( Byte( MSGTOLENGTH , (int)( 1 ) ) ) ) == "\u0021"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1274;
                    MSGREMAINDER  .UpdateValue ( Functions.Gather ( Byte( MSGTOLENGTH , (int)( 5 ) ), FROM_DEVICE )  ) ; 
                    __context__.SourceCodeLine = 1275;
                    MakeString ( UMODULE . SLASTMSGIN , "{0}{1}", MSGTOLENGTH , MSGREMAINDER ) ; 
                    __context__.SourceCodeLine = 1277;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( MSGTOLENGTH , (int)( 2 ) ) == MONITOR_ID  .Value))  ) ) 
                        {
                        __context__.SourceCodeLine = 1278;
                        PROCESSDEVICEMSG (  __context__  ) ; 
                        }
                    
                    } 
                
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 1283;
                /* Trace( "Issue with Device message handling\r\n") */ ; 
                
                }
                
                __context__.SourceCodeLine = 1266;
                } 
            
            
            
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
        
        __context__.SourceCodeLine = 1326;
        SINPUTCOMMANDS [ 1 ]  .UpdateValue ( "\u0003"  ) ; 
        __context__.SourceCodeLine = 1327;
        SINPUTCOMMANDS [ 2 ]  .UpdateValue ( "\u0004"  ) ; 
        __context__.SourceCodeLine = 1328;
        SINPUTCOMMANDS [ 3 ]  .UpdateValue ( "\u0005"  ) ; 
        __context__.SourceCodeLine = 1329;
        SINPUTCOMMANDS [ 4 ]  .UpdateValue ( "\u0006"  ) ; 
        __context__.SourceCodeLine = 1330;
        SINPUTCOMMANDS [ 5 ]  .UpdateValue ( "\u0007"  ) ; 
        __context__.SourceCodeLine = 1331;
        SINPUTCOMMANDS [ 6 ]  .UpdateValue ( "\u0008"  ) ; 
        __context__.SourceCodeLine = 1332;
        SINPUTCOMMANDS [ 7 ]  .UpdateValue ( "\u0009"  ) ; 
        __context__.SourceCodeLine = 1333;
        SINPUTCOMMANDS [ 8 ]  .UpdateValue ( "\u000A"  ) ; 
        __context__.SourceCodeLine = 1335;
        SINPUTTRACKING [ 1 ]  .UpdateValue ( "HDMI_1"  ) ; 
        __context__.SourceCodeLine = 1336;
        SINPUTTRACKING [ 2 ]  .UpdateValue ( "HDMI_2"  ) ; 
        __context__.SourceCodeLine = 1337;
        SINPUTTRACKING [ 3 ]  .UpdateValue ( "DISPLAYPORT"  ) ; 
        __context__.SourceCodeLine = 1338;
        SINPUTTRACKING [ 4 ]  .UpdateValue ( "CARD_OPS"  ) ; 
        __context__.SourceCodeLine = 1339;
        SINPUTTRACKING [ 5 ]  .UpdateValue ( "DVI_D"  ) ; 
        __context__.SourceCodeLine = 1340;
        SINPUTTRACKING [ 6 ]  .UpdateValue ( "YPBPR"  ) ; 
        __context__.SourceCodeLine = 1341;
        SINPUTTRACKING [ 7 ]  .UpdateValue ( "AV"  ) ; 
        __context__.SourceCodeLine = 1342;
        SINPUTTRACKING [ 8 ]  .UpdateValue ( "VGA"  ) ; 
        __context__.SourceCodeLine = 1344;
        SIRCOMMANDS [ 1 ]  .UpdateValue ( "\u00A0"  ) ; 
        __context__.SourceCodeLine = 1345;
        SIRCOMMANDS [ 2 ]  .UpdateValue ( "\u00A1"  ) ; 
        __context__.SourceCodeLine = 1346;
        SIRCOMMANDS [ 3 ]  .UpdateValue ( "\u00A2"  ) ; 
        __context__.SourceCodeLine = 1347;
        SIRCOMMANDS [ 4 ]  .UpdateValue ( "\u00A3"  ) ; 
        __context__.SourceCodeLine = 1348;
        SIRCOMMANDS [ 5 ]  .UpdateValue ( "\u00A4"  ) ; 
        __context__.SourceCodeLine = 1349;
        SIRCOMMANDS [ 6 ]  .UpdateValue ( "\u00A5"  ) ; 
        __context__.SourceCodeLine = 1350;
        SIRCOMMANDS [ 7 ]  .UpdateValue ( "\u00A6"  ) ; 
        __context__.SourceCodeLine = 1351;
        SIRCOMMANDS [ 8 ]  .UpdateValue ( "\u00A7"  ) ; 
        __context__.SourceCodeLine = 1352;
        SIRCOMMANDS [ 9 ]  .UpdateValue ( "\u00A8"  ) ; 
        __context__.SourceCodeLine = 1353;
        SIRCOMMANDS [ 10 ]  .UpdateValue ( "\u00A9"  ) ; 
        __context__.SourceCodeLine = 1354;
        SIRCOMMANDS [ 11 ]  .UpdateValue ( "\u00B1"  ) ; 
        __context__.SourceCodeLine = 1355;
        SIRCOMMANDS [ 12 ]  .UpdateValue ( "\u00B2"  ) ; 
        __context__.SourceCodeLine = 1356;
        SIRCOMMANDS [ 13 ]  .UpdateValue ( "\u00C1"  ) ; 
        __context__.SourceCodeLine = 1357;
        SIRCOMMANDS [ 14 ]  .UpdateValue ( "\u00C2"  ) ; 
        __context__.SourceCodeLine = 1358;
        SIRCOMMANDS [ 15 ]  .UpdateValue ( "\u00C3"  ) ; 
        __context__.SourceCodeLine = 1359;
        SIRCOMMANDS [ 16 ]  .UpdateValue ( "\u00C4"  ) ; 
        __context__.SourceCodeLine = 1360;
        SIRCOMMANDS [ 17 ]  .UpdateValue ( "\u00D1"  ) ; 
        __context__.SourceCodeLine = 1361;
        SIRCOMMANDS [ 18 ]  .UpdateValue ( "\u00D2"  ) ; 
        __context__.SourceCodeLine = 1362;
        SIRCOMMANDS [ 19 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1363;
        SIRCOMMANDS [ 20 ]  .UpdateValue ( "\u0001"  ) ; 
        __context__.SourceCodeLine = 1364;
        SIRCOMMANDS [ 21 ]  .UpdateValue ( "\u0002"  ) ; 
        __context__.SourceCodeLine = 1365;
        SIRCOMMANDS [ 22 ]  .UpdateValue ( "\u0003"  ) ; 
        __context__.SourceCodeLine = 1366;
        SIRCOMMANDS [ 23 ]  .UpdateValue ( "\u0004"  ) ; 
        __context__.SourceCodeLine = 1367;
        SIRCOMMANDS [ 24 ]  .UpdateValue ( "\u0005"  ) ; 
        __context__.SourceCodeLine = 1368;
        SIRCOMMANDS [ 25 ]  .UpdateValue ( "\u0006"  ) ; 
        __context__.SourceCodeLine = 1369;
        SIRCOMMANDS [ 26 ]  .UpdateValue ( "\u0007"  ) ; 
        __context__.SourceCodeLine = 1370;
        SIRCOMMANDS [ 27 ]  .UpdateValue ( "\u0008"  ) ; 
        __context__.SourceCodeLine = 1371;
        SIRCOMMANDS [ 28 ]  .UpdateValue ( "\u0009"  ) ; 
        __context__.SourceCodeLine = 1373;
        SIRTRACKING [ 1 ]  .UpdateValue ( "POWER"  ) ; 
        __context__.SourceCodeLine = 1374;
        SIRTRACKING [ 2 ]  .UpdateValue ( "MENU"  ) ; 
        __context__.SourceCodeLine = 1375;
        SIRTRACKING [ 3 ]  .UpdateValue ( "INPUT"  ) ; 
        __context__.SourceCodeLine = 1376;
        SIRTRACKING [ 4 ]  .UpdateValue ( "VOL_UP"  ) ; 
        __context__.SourceCodeLine = 1377;
        SIRTRACKING [ 5 ]  .UpdateValue ( "VOL_DN"  ) ; 
        __context__.SourceCodeLine = 1378;
        SIRTRACKING [ 6 ]  .UpdateValue ( "VOL_MUTE"  ) ; 
        __context__.SourceCodeLine = 1379;
        SIRTRACKING [ 7 ]  .UpdateValue ( "UP"  ) ; 
        __context__.SourceCodeLine = 1380;
        SIRTRACKING [ 8 ]  .UpdateValue ( "DOWN"  ) ; 
        __context__.SourceCodeLine = 1381;
        SIRTRACKING [ 9 ]  .UpdateValue ( "LEFT"  ) ; 
        __context__.SourceCodeLine = 1382;
        SIRTRACKING [ 10 ]  .UpdateValue ( "RIGHT"  ) ; 
        __context__.SourceCodeLine = 1383;
        SIRTRACKING [ 11 ]  .UpdateValue ( "OK"  ) ; 
        __context__.SourceCodeLine = 1384;
        SIRTRACKING [ 12 ]  .UpdateValue ( "RETURN"  ) ; 
        __context__.SourceCodeLine = 1385;
        SIRTRACKING [ 13 ]  .UpdateValue ( "RED"  ) ; 
        __context__.SourceCodeLine = 1386;
        SIRTRACKING [ 14 ]  .UpdateValue ( "GREEN"  ) ; 
        __context__.SourceCodeLine = 1387;
        SIRTRACKING [ 15 ]  .UpdateValue ( "YELLOW"  ) ; 
        __context__.SourceCodeLine = 1388;
        SIRTRACKING [ 16 ]  .UpdateValue ( "BLUE"  ) ; 
        __context__.SourceCodeLine = 1389;
        SIRTRACKING [ 17 ]  .UpdateValue ( "FORMAT"  ) ; 
        __context__.SourceCodeLine = 1390;
        SIRTRACKING [ 18 ]  .UpdateValue ( "INFO"  ) ; 
        __context__.SourceCodeLine = 1391;
        SIRTRACKING [ 19 ]  .UpdateValue ( "0"  ) ; 
        __context__.SourceCodeLine = 1392;
        SIRTRACKING [ 20 ]  .UpdateValue ( "1"  ) ; 
        __context__.SourceCodeLine = 1393;
        SIRTRACKING [ 21 ]  .UpdateValue ( "2"  ) ; 
        __context__.SourceCodeLine = 1394;
        SIRTRACKING [ 22 ]  .UpdateValue ( "3"  ) ; 
        __context__.SourceCodeLine = 1395;
        SIRTRACKING [ 23 ]  .UpdateValue ( "4"  ) ; 
        __context__.SourceCodeLine = 1396;
        SIRTRACKING [ 24 ]  .UpdateValue ( "5"  ) ; 
        __context__.SourceCodeLine = 1397;
        SIRTRACKING [ 25 ]  .UpdateValue ( "6"  ) ; 
        __context__.SourceCodeLine = 1398;
        SIRTRACKING [ 26 ]  .UpdateValue ( "7"  ) ; 
        __context__.SourceCodeLine = 1399;
        SIRTRACKING [ 27 ]  .UpdateValue ( "8"  ) ; 
        __context__.SourceCodeLine = 1400;
        SIRTRACKING [ 28 ]  .UpdateValue ( "9"  ) ; 
        __context__.SourceCodeLine = 1402;
        UMODULE . NISHEARTBEATING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1403;
        UMODULE . NISPOLLING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1405;
        RESET (  __context__  ) ; 
        __context__.SourceCodeLine = 1407;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    SCOMMANDQUEUE  = new CrestronString[ 51 ];
    for( uint i = 0; i < 51; i++ )
        SCOMMANDQUEUE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    SSTATUSQUEUE  = new CrestronString[ 51 ];
    for( uint i = 0; i < 51; i++ )
        SSTATUSQUEUE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    SINPUTCOMMANDS  = new CrestronString[ 9 ];
    for( uint i = 0; i < 9; i++ )
        SINPUTCOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SINPUTTRACKING  = new CrestronString[ 9 ];
    for( uint i = 0; i < 9; i++ )
        SINPUTTRACKING [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SIRCOMMANDS  = new CrestronString[ 29 ];
    for( uint i = 0; i < 29; i++ )
        SIRCOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SIRTRACKING  = new CrestronString[ 29 ];
    for( uint i = 0; i < 29; i++ )
        SIRTRACKING [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    UMODULE  = new _MODULESTATUS( this, true );
    UMODULE .PopulateCustomAttributeList( false );
    UDEVICE  = new _DEVICESTATUS( this, true );
    UDEVICE .PopulateCustomAttributeList( false );
    UQUEUE  = new _QUEUE( this, true );
    UQUEUE .PopulateCustomAttributeList( false );
    
    CONNECT = new Crestron.Logos.SplusObjects.DigitalInput( CONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( CONNECT__DigitalInput__, CONNECT );
    
    DISCONNECT = new Crestron.Logos.SplusObjects.DigitalInput( DISCONNECT__DigitalInput__, this );
    m_DigitalInputList.Add( DISCONNECT__DigitalInput__, DISCONNECT );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    POWER_ON = new Crestron.Logos.SplusObjects.DigitalInput( POWER_ON__DigitalInput__, this );
    m_DigitalInputList.Add( POWER_ON__DigitalInput__, POWER_ON );
    
    POWER_OFF = new Crestron.Logos.SplusObjects.DigitalInput( POWER_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( POWER_OFF__DigitalInput__, POWER_OFF );
    
    POWER_TOGGLE = new Crestron.Logos.SplusObjects.DigitalInput( POWER_TOGGLE__DigitalInput__, this );
    m_DigitalInputList.Add( POWER_TOGGLE__DigitalInput__, POWER_TOGGLE );
    
    VOLUME_UP = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_UP__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_UP__DigitalInput__, VOLUME_UP );
    
    VOLUME_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_DOWN__DigitalInput__, VOLUME_DOWN );
    
    VOLUME_MUTE_ON = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_MUTE_ON__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_MUTE_ON__DigitalInput__, VOLUME_MUTE_ON );
    
    VOLUME_MUTE_OFF = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_MUTE_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_MUTE_OFF__DigitalInput__, VOLUME_MUTE_OFF );
    
    VOLUME_MUTE_TOGGLE = new Crestron.Logos.SplusObjects.DigitalInput( VOLUME_MUTE_TOGGLE__DigitalInput__, this );
    m_DigitalInputList.Add( VOLUME_MUTE_TOGGLE__DigitalInput__, VOLUME_MUTE_TOGGLE );
    
    BACKLIGHT_UP = new Crestron.Logos.SplusObjects.DigitalInput( BACKLIGHT_UP__DigitalInput__, this );
    m_DigitalInputList.Add( BACKLIGHT_UP__DigitalInput__, BACKLIGHT_UP );
    
    BACKLIGHT_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( BACKLIGHT_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( BACKLIGHT_DOWN__DigitalInput__, BACKLIGHT_DOWN );
    
    POLL_ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( POLL_ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( POLL_ENABLE__DigitalInput__, POLL_ENABLE );
    
    INPUT_CYCLE = new Crestron.Logos.SplusObjects.DigitalInput( INPUT_CYCLE__DigitalInput__, this );
    m_DigitalInputList.Add( INPUT_CYCLE__DigitalInput__, INPUT_CYCLE );
    
    INPUTS = new InOutArray<DigitalInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        INPUTS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( INPUTS__DigitalInput__ + i, INPUTS__DigitalInput__, this );
        m_DigitalInputList.Add( INPUTS__DigitalInput__ + i, INPUTS[i+1] );
    }
    
    IR_COMMANDS = new InOutArray<DigitalInput>( 28, this );
    for( uint i = 0; i < 28; i++ )
    {
        IR_COMMANDS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( IR_COMMANDS__DigitalInput__ + i, IR_COMMANDS__DigitalInput__, this );
        m_DigitalInputList.Add( IR_COMMANDS__DigitalInput__ + i, IR_COMMANDS[i+1] );
    }
    
    IS_COMMUNICATING = new Crestron.Logos.SplusObjects.DigitalOutput( IS_COMMUNICATING__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_COMMUNICATING__DigitalOutput__, IS_COMMUNICATING );
    
    IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
    
    POWER_IS_ON = new Crestron.Logos.SplusObjects.DigitalOutput( POWER_IS_ON__DigitalOutput__, this );
    m_DigitalOutputList.Add( POWER_IS_ON__DigitalOutput__, POWER_IS_ON );
    
    VOLUME_IS_MUTED = new Crestron.Logos.SplusObjects.DigitalOutput( VOLUME_IS_MUTED__DigitalOutput__, this );
    m_DigitalOutputList.Add( VOLUME_IS_MUTED__DigitalOutput__, VOLUME_IS_MUTED );
    
    IS_POLLING = new Crestron.Logos.SplusObjects.DigitalOutput( IS_POLLING__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_POLLING__DigitalOutput__, IS_POLLING );
    
    INPUTS_FB = new InOutArray<DigitalOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        INPUTS_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( INPUTS_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( INPUTS_FB__DigitalOutput__ + i, INPUTS_FB[i+1] );
    }
    
    VOLUME_SET = new Crestron.Logos.SplusObjects.AnalogInput( VOLUME_SET__AnalogSerialInput__, this );
    m_AnalogInputList.Add( VOLUME_SET__AnalogSerialInput__, VOLUME_SET );
    
    BACKLIGHT_SET = new Crestron.Logos.SplusObjects.AnalogInput( BACKLIGHT_SET__AnalogSerialInput__, this );
    m_AnalogInputList.Add( BACKLIGHT_SET__AnalogSerialInput__, BACKLIGHT_SET );
    
    VOLUME_LEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( VOLUME_LEVEL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( VOLUME_LEVEL__AnalogSerialOutput__, VOLUME_LEVEL );
    
    BACKLIGHT_LEVEL = new Crestron.Logos.SplusObjects.AnalogOutput( BACKLIGHT_LEVEL__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( BACKLIGHT_LEVEL__AnalogSerialOutput__, BACKLIGHT_LEVEL );
    
    TO_DEVICE = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__AnalogSerialOutput__, TO_DEVICE );
    
    FROM_DEVICE = new Crestron.Logos.SplusObjects.BufferInput( FROM_DEVICE__AnalogSerialInput__, 10000, this );
    m_StringInputList.Add( FROM_DEVICE__AnalogSerialInput__, FROM_DEVICE );
    
    MONITOR_ID = new UShortParameter( MONITOR_ID__Parameter__, this );
    m_ParameterList.Add( MONITOR_ID__Parameter__, MONITOR_ID );
    
    VOLUME_STEP_SIZE = new UShortParameter( VOLUME_STEP_SIZE__Parameter__, this );
    m_ParameterList.Add( VOLUME_STEP_SIZE__Parameter__, VOLUME_STEP_SIZE );
    
    BACKLIGHT_STEP_SIZE = new UShortParameter( BACKLIGHT_STEP_SIZE__Parameter__, this );
    m_ParameterList.Add( BACKLIGHT_STEP_SIZE__Parameter__, BACKLIGHT_STEP_SIZE );
    
    QUEUEFALSERESPONSE_Callback = new WaitFunction( QUEUEFALSERESPONSE_CallbackFn );
    POLL_Callback = new WaitFunction( POLL_CallbackFn );
    STARTPOLLINGPROCESS_Callback = new WaitFunction( STARTPOLLINGPROCESS_CallbackFn );
    HEARTBEAT_Callback = new WaitFunction( HEARTBEAT_CallbackFn );
    STARTHEARTBEATPROCESS_Callback = new WaitFunction( STARTHEARTBEATPROCESS_CallbackFn );
    
    CONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONNECT_OnPush_0, false ) );
    DISCONNECT.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISCONNECT_OnPush_1, false ) );
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_2, false ) );
    POWER_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( POWER_ON_OnPush_3, false ) );
    POWER_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( POWER_OFF_OnPush_4, false ) );
    POWER_TOGGLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( POWER_TOGGLE_OnPush_5, false ) );
    for( uint i = 0; i < 8; i++ )
        INPUTS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( INPUTS_OnPush_6, false ) );
        
    INPUT_CYCLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INPUT_CYCLE_OnPush_7, false ) );
    VOLUME_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_UP_OnPush_8, false ) );
    VOLUME_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_DOWN_OnPush_9, false ) );
    VOLUME_MUTE_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_MUTE_ON_OnPush_10, false ) );
    VOLUME_MUTE_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_MUTE_OFF_OnPush_11, false ) );
    VOLUME_MUTE_TOGGLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_MUTE_TOGGLE_OnPush_12, false ) );
    VOLUME_SET.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_SET_OnChange_13, false ) );
    BACKLIGHT_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( BACKLIGHT_UP_OnPush_14, false ) );
    BACKLIGHT_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( BACKLIGHT_DOWN_OnPush_15, false ) );
    BACKLIGHT_SET.OnAnalogChange.Add( new InputChangeHandlerWrapper( BACKLIGHT_SET_OnChange_16, false ) );
    for( uint i = 0; i < 28; i++ )
        IR_COMMANDS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( IR_COMMANDS_OnPush_17, false ) );
        
    POLL_ENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnPush_18, false ) );
    POLL_ENABLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnRelease_19, false ) );
    FROM_DEVICE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE_OnChange_20, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PLANAR_RA_SERIES_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction QUEUEFALSERESPONSE_Callback;
private WaitFunction POLL_Callback;
private WaitFunction STARTPOLLINGPROCESS_Callback;
private WaitFunction HEARTBEAT_Callback;
private WaitFunction STARTHEARTBEATPROCESS_Callback;


const uint CONNECT__DigitalInput__ = 0;
const uint DISCONNECT__DigitalInput__ = 1;
const uint INITIALIZE__DigitalInput__ = 2;
const uint POWER_ON__DigitalInput__ = 3;
const uint POWER_OFF__DigitalInput__ = 4;
const uint POWER_TOGGLE__DigitalInput__ = 5;
const uint VOLUME_UP__DigitalInput__ = 6;
const uint VOLUME_DOWN__DigitalInput__ = 7;
const uint VOLUME_MUTE_ON__DigitalInput__ = 8;
const uint VOLUME_MUTE_OFF__DigitalInput__ = 9;
const uint VOLUME_MUTE_TOGGLE__DigitalInput__ = 10;
const uint BACKLIGHT_UP__DigitalInput__ = 11;
const uint BACKLIGHT_DOWN__DigitalInput__ = 12;
const uint POLL_ENABLE__DigitalInput__ = 13;
const uint INPUT_CYCLE__DigitalInput__ = 14;
const uint INPUTS__DigitalInput__ = 15;
const uint IR_COMMANDS__DigitalInput__ = 23;
const uint VOLUME_SET__AnalogSerialInput__ = 0;
const uint BACKLIGHT_SET__AnalogSerialInput__ = 1;
const uint FROM_DEVICE__AnalogSerialInput__ = 2;
const uint IS_COMMUNICATING__DigitalOutput__ = 0;
const uint IS_INITIALIZED__DigitalOutput__ = 1;
const uint POWER_IS_ON__DigitalOutput__ = 2;
const uint VOLUME_IS_MUTED__DigitalOutput__ = 3;
const uint IS_POLLING__DigitalOutput__ = 4;
const uint INPUTS_FB__DigitalOutput__ = 5;
const uint VOLUME_LEVEL__AnalogSerialOutput__ = 0;
const uint BACKLIGHT_LEVEL__AnalogSerialOutput__ = 1;
const uint TO_DEVICE__AnalogSerialOutput__ = 2;
const uint MONITOR_ID__Parameter__ = 10;
const uint VOLUME_STEP_SIZE__Parameter__ = 11;
const uint BACKLIGHT_STEP_SIZE__Parameter__ = 12;

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
public class _MODULESTATUS : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  NISCOMMUNICATING = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  NISINITIALIZING = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  NISINITIALIZED = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  NISPARSING = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  NISHEARTBEATING = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  NISPOLLING = 0;
    
    [SplusStructAttribute(6, false, false)]
    public CrestronString  SLASTMSGIN;
    
    
    public _MODULESTATUS( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SLASTMSGIN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, Owner );
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class _DEVICESTATUS : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public ushort  NPOWER = 0;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  NINPUT = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  NVOLUMELEVEL = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  NLASTVOLUMELEVEL = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  NVOLUMEMUTE = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  NBACKLIGHTLEVEL = 0;
    
    
    public _DEVICESTATUS( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        
        
    }
    
}
[SplusStructAttribute(-1, true, false)]
public class _QUEUE : SplusStructureBase
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
    public CrestronString  SLASTMSGOUT;
    
    
    public _QUEUE( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        SLASTMSGOUT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, Owner );
        
        
    }
    
}

}
