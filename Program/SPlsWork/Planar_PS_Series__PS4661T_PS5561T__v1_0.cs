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

namespace UserModule_PLANAR_PS_SERIES__PS4661T_PS5561T__V1_0
{
    public class UserModuleClass_PLANAR_PS_SERIES__PS4661T_PS5561T__V1_0 : SplusObject
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
        Crestron.Logos.SplusObjects.DigitalInput WAKE_MODE_CYCLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> INPUTS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> WAKE_MODES;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> REMOTE_COMMANDS;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME_SET;
        Crestron.Logos.SplusObjects.AnalogInput BACKLIGHT_SET;
        Crestron.Logos.SplusObjects.BufferInput FROM_DEVICE;
        Crestron.Logos.SplusObjects.DigitalOutput IS_COMMUNICATING;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.DigitalOutput POWER_IS_ON;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_IS_MUTED;
        Crestron.Logos.SplusObjects.DigitalOutput IS_POLLING;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> INPUTS_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> WAKE_MODES_FB;
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
        CrestronString [] SWAKEMODECOMMANDS;
        CrestronString [] SREMOTECOMMANDS;
        private ushort CONTAINS (  SplusExecutionContext __context__, CrestronString MATCHSTRING , CrestronString SOURCESTRING ) 
            { 
            
            __context__.SourceCodeLine = 238;
            return (ushort)( Functions.BoolToInt ( Functions.Find( MATCHSTRING , SOURCESTRING ) > 0 )) ; 
            
            }
            
        private CrestronString GETBOUNDSTRING (  SplusExecutionContext __context__, CrestronString SOURCE , CrestronString STARTSTRING , CrestronString ENDSTRING ) 
            { 
            ushort STARTINDEX = 0;
            
            ushort ENDINDEX = 0;
            
            CrestronString RESPONSE;
            RESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 247;
            RESPONSE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 249;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOURCE ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 251;
                STARTINDEX = (ushort) ( Functions.Find( STARTSTRING , SOURCE ) ) ; 
                __context__.SourceCodeLine = 252;
                ENDINDEX = (ushort) ( Functions.Find( ENDSTRING , SOURCE , (STARTINDEX + 1) ) ) ; 
                __context__.SourceCodeLine = 254;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX < ENDINDEX ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 256;
                    STARTINDEX = (ushort) ( (STARTINDEX + Functions.Length( STARTSTRING )) ) ; 
                    __context__.SourceCodeLine = 257;
                    RESPONSE  .UpdateValue ( Functions.Mid ( SOURCE ,  (int) ( STARTINDEX ) ,  (int) ( (ENDINDEX - STARTINDEX) ) )  ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 261;
            return ( RESPONSE ) ; 
            
            }
            
        private CrestronString BUILDSETMSG (  SplusExecutionContext __context__, ushort MONITORID , CrestronString COMMAND , CrestronString VALUE ) 
            { 
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 272;
            MakeString ( MSG , "{0}{1}", MSG , "\u0007" ) ; 
            __context__.SourceCodeLine = 273;
            MakeString ( MSG , "{0}{1}", MSG , Functions.Chr (  (int) ( MONITORID ) ) ) ; 
            __context__.SourceCodeLine = 274;
            MakeString ( MSG , "{0}{1}", MSG , "\u0002" ) ; 
            __context__.SourceCodeLine = 275;
            MakeString ( MSG , "{0}{1}", MSG , COMMAND ) ; 
            __context__.SourceCodeLine = 276;
            MakeString ( MSG , "{0}{1}", MSG , VALUE ) ; 
            __context__.SourceCodeLine = 277;
            MakeString ( MSG , "{0}{1}", MSG , "\u0008" ) ; 
            __context__.SourceCodeLine = 279;
            return ( MSG ) ; 
            
            }
            
        private CrestronString BUILDGETMSG (  SplusExecutionContext __context__, ushort MONITORID , CrestronString COMMAND ) 
            { 
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 286;
            MakeString ( MSG , "{0}{1}", MSG , "\u0007" ) ; 
            __context__.SourceCodeLine = 287;
            MakeString ( MSG , "{0}{1}", MSG , Functions.Chr (  (int) ( MONITORID ) ) ) ; 
            __context__.SourceCodeLine = 288;
            MakeString ( MSG , "{0}{1}", MSG , "\u0001" ) ; 
            __context__.SourceCodeLine = 289;
            MakeString ( MSG , "{0}{1}", MSG , COMMAND ) ; 
            __context__.SourceCodeLine = 290;
            MakeString ( MSG , "{0}{1}", MSG , "\u0008" ) ; 
            __context__.SourceCodeLine = 292;
            return ( MSG ) ; 
            
            }
            
        private void RESETQUEUE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 301;
            UQUEUE . NBUSY = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 302;
            UQUEUE . NHASITEMS = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 303;
            UQUEUE . NCOMMANDHEAD = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 304;
            UQUEUE . NCOMMANDTAIL = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 305;
            UQUEUE . NSTATUSHEAD = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 306;
            UQUEUE . NSTATUSTAIL = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 307;
            UQUEUE . NSTRIKECOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 308;
            UQUEUE . SLASTMSGOUT  .UpdateValue ( ""  ) ; 
            
            }
            
        private void RESETMODULE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 313;
            UMODULE . NISCOMMUNICATING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 314;
            UMODULE . NISINITIALIZING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 315;
            UMODULE . NISINITIALIZED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 316;
            UMODULE . NISPARSING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 317;
            UMODULE . NISPOLLING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 318;
            UMODULE . SLASTMSGIN  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 320;
            IS_COMMUNICATING  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 321;
            IS_INITIALIZED  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RESETDEVICE (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 328;
            UDEVICE . NPOWER = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 329;
            UDEVICE . NINPUT = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 330;
            UDEVICE . NVOLUMELEVEL = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 331;
            UDEVICE . NVOLUMEMUTE = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 332;
            UDEVICE . NBACKLIGHTLEVEL = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 333;
            UDEVICE . NWAKEMODE = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 335;
            POWER_IS_ON  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 336;
            VOLUME_IS_MUTED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 337;
            VOLUME_LEVEL  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 338;
            BACKLIGHT_LEVEL  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 340;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)4; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 341;
                INPUTS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 340;
                }
            
            __context__.SourceCodeLine = 343;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)3; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                {
                __context__.SourceCodeLine = 344;
                WAKE_MODES_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 343;
                }
            
            
            }
            
        private void RESET (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 349;
            /* Trace( "reset") */ ; 
            __context__.SourceCodeLine = 351;
            RESETQUEUE (  __context__  ) ; 
            __context__.SourceCodeLine = 352;
            RESETMODULE (  __context__  ) ; 
            __context__.SourceCodeLine = 353;
            RESETDEVICE (  __context__  ) ; 
            
            }
            
        private ushort ISQUEUEEMPTY (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 362;
            return (ushort)( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NHASITEMS == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NBUSY == 0) )) )) ; 
            
            }
            
        private CrestronString DEQUEUE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SCMD;
            SCMD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 369;
            SCMD  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 371;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NHASITEMS == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NBUSY == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 373;
                UQUEUE . NBUSY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 376;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDHEAD != UQUEUE.NCOMMANDTAIL))  ) ) 
                    { 
                    __context__.SourceCodeLine = 378;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDTAIL == Functions.GetNumArrayRows( SCOMMANDQUEUE )))  ) ) 
                        {
                        __context__.SourceCodeLine = 379;
                        UQUEUE . NCOMMANDTAIL = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 381;
                        UQUEUE . NCOMMANDTAIL = (ushort) ( (UQUEUE.NCOMMANDTAIL + 1) ) ; 
                        }
                    
                    __context__.SourceCodeLine = 383;
                    UQUEUE . SLASTMSGOUT  .UpdateValue ( SCOMMANDQUEUE [ UQUEUE.NCOMMANDTAIL ]  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 386;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSHEAD != UQUEUE.NSTATUSTAIL))  ) ) 
                        { 
                        __context__.SourceCodeLine = 388;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSTAIL == Functions.GetNumArrayRows( SSTATUSQUEUE )))  ) ) 
                            {
                            __context__.SourceCodeLine = 389;
                            UQUEUE . NSTATUSTAIL = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 391;
                            UQUEUE . NSTATUSTAIL = (ushort) ( (UQUEUE.NSTATUSTAIL + 1) ) ; 
                            }
                        
                        __context__.SourceCodeLine = 393;
                        UQUEUE . SLASTMSGOUT  .UpdateValue ( SSTATUSQUEUE [ UQUEUE.NSTATUSTAIL ]  ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 396;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NCOMMANDHEAD == UQUEUE.NCOMMANDTAIL) ) && Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NSTATUSHEAD == UQUEUE.NSTATUSTAIL) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 397;
                    UQUEUE . NHASITEMS = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 399;
                SCMD  .UpdateValue ( UQUEUE . SLASTMSGOUT  ) ; 
                } 
            
            __context__.SourceCodeLine = 402;
            return ( SCMD ) ; 
            
            }
            
        private void SENDNEXTQUEUEITEM (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SOUTGOING;
            SOUTGOING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            CrestronString SGARBAGE;
            SGARBAGE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 410;
            SOUTGOING  .UpdateValue ( DEQUEUE (  __context__  )  ) ; 
            __context__.SourceCodeLine = 412;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOUTGOING ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 414;
                /* Trace( "sendNextQueueItem() - sending next message") */ ; 
                __context__.SourceCodeLine = 416;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "<HEARTBEAT>" , SOUTGOING ) == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 418;
                    SGARBAGE  .UpdateValue ( Functions.Remove ( "<HEARTBEAT>" , SOUTGOING )  ) ; 
                    __context__.SourceCodeLine = 419;
                    UMODULE . NLASTOUTWASHEARTBEAT = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 422;
                    UMODULE . NLASTOUTWASHEARTBEAT = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 424;
                MakeString ( TO_DEVICE , "{0}", SOUTGOING ) ; 
                __context__.SourceCodeLine = 426;
                CreateWait ( "QUEUEFALSERESPONSE" , 250 , QUEUEFALSERESPONSE_Callback ) ;
                } 
            
            else 
                {
                __context__.SourceCodeLine = 449;
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
                
            
            __context__.SourceCodeLine = 428;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NBUSY == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 430;
                UQUEUE . NBUSY = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 432;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UQUEUE.NSTRIKECOUNT < 3 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 434;
                    UQUEUE . NSTRIKECOUNT = (ushort) ( (UQUEUE.NSTRIKECOUNT + 1) ) ; 
                    __context__.SourceCodeLine = 436;
                    /* Trace( "Failed Response") */ ; 
                    __context__.SourceCodeLine = 437;
                    /* Trace( "Strike Count[{0:d}]", (ushort)UQUEUE.NSTRIKECOUNT) */ ; 
                    __context__.SourceCodeLine = 441;
                    SENDNEXTQUEUEITEM (  __context__  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 444;
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
        
        
        __context__.SourceCodeLine = 456;
        NQUEUEWASEMPTY = (ushort) ( ISQUEUEEMPTY( __context__ ) ) ; 
        __context__.SourceCodeLine = 458;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BPRIORITY == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 460;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDHEAD == Functions.GetNumArrayRows( SCOMMANDQUEUE )))  ) ) 
                { 
                __context__.SourceCodeLine = 462;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDTAIL != 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 464;
                    UQUEUE . NCOMMANDHEAD = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 465;
                    SCOMMANDQUEUE [ UQUEUE.NCOMMANDHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 466;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 469;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDTAIL != (UQUEUE.NCOMMANDHEAD + 1)))  ) ) 
                    { 
                    __context__.SourceCodeLine = 471;
                    UQUEUE . NCOMMANDHEAD = (ushort) ( (UQUEUE.NCOMMANDHEAD + 1) ) ; 
                    __context__.SourceCodeLine = 472;
                    SCOMMANDQUEUE [ UQUEUE.NCOMMANDHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 473;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                }
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 478;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSHEAD == Functions.GetNumArrayRows( SSTATUSQUEUE )))  ) ) 
                { 
                __context__.SourceCodeLine = 480;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSTAIL != 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 482;
                    UQUEUE . NSTATUSHEAD = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 483;
                    SSTATUSQUEUE [ UQUEUE.NSTATUSHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 484;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 487;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSTAIL != (UQUEUE.NSTATUSHEAD + 1)))  ) ) 
                    { 
                    __context__.SourceCodeLine = 489;
                    UQUEUE . NSTATUSHEAD = (ushort) ( (UQUEUE.NSTATUSHEAD + 1) ) ; 
                    __context__.SourceCodeLine = 490;
                    SSTATUSQUEUE [ UQUEUE.NSTATUSHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 491;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                }
            
            } 
        
        __context__.SourceCodeLine = 495;
        if ( Functions.TestForTrue  ( ( NQUEUEWASEMPTY)  ) ) 
            {
            __context__.SourceCodeLine = 496;
            SENDNEXTQUEUEITEM (  __context__  ) ; 
            }
        
        
        }
        
    private void SETPOWER (  SplusExecutionContext __context__, ushort MONITORID , ushort STATE ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 507;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (STATE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (STATE == 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 509;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)STATE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 511;
                        MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "POW", "\u0001") ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                        {
                        __context__.SourceCodeLine = 512;
                        MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "POW", "\u0000") ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 515;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
            } 
        
        
        }
        
    private void GETPOWER (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 523;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "POW") ) ; 
        __context__.SourceCodeLine = 524;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETINPUT (  SplusExecutionContext __context__, ushort MONITORID , ushort INPUT ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 531;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 1) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 533;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INPUT > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INPUT <= 4 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 535;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "MIN", SINPUTCOMMANDS[ INPUT ]) ) ; 
                __context__.SourceCodeLine = 536;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETINPUT (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 545;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "MIN") ) ; 
        __context__.SourceCodeLine = 546;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETVOLUME (  SplusExecutionContext __context__, ushort MONITORID , ushort LEVEL ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 553;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 1) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 555;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( LEVEL >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( LEVEL <= 100 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 557;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "VOL", Functions.Chr( (int)( LEVEL ) )) ) ; 
                __context__.SourceCodeLine = 558;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETVOLUME (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 567;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "VOL") ) ; 
        __context__.SourceCodeLine = 568;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETVOLUMEMUTE (  SplusExecutionContext __context__, ushort MONITORID , ushort STATE ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 575;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 1) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 577;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (STATE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (STATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 579;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_2__ = ((int)STATE);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                            {
                            __context__.SourceCodeLine = 581;
                            MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "MUT", "\u0001") ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 0) ) ) ) 
                            {
                            __context__.SourceCodeLine = 582;
                            MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "MUT", "\u0000") ) ; 
                            }
                        
                        } 
                        
                    }
                    
                
                __context__.SourceCodeLine = 585;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETVOLUMEMUTE (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 594;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "MUT") ) ; 
        __context__.SourceCodeLine = 595;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETWAKEMODE (  SplusExecutionContext __context__, ushort MONITORID , ushort MODE ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 602;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 1) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 604;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( MODE > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( MODE <= 3 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 606;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "WFS", SWAKEMODECOMMANDS[ MODE ]) ) ; 
                __context__.SourceCodeLine = 607;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETWAKEMODE (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 616;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "WFS") ) ; 
        __context__.SourceCodeLine = 617;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SENDIR (  SplusExecutionContext __context__, ushort MONITORID , ushort IRFUNCTION ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 624;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 1) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 626;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IRFUNCTION > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IRFUNCTION <= 8 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 628;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "RCU", SREMOTECOMMANDS[ IRFUNCTION ]) ) ; 
                __context__.SourceCodeLine = 629;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void SETBACKLIGHT (  SplusExecutionContext __context__, ushort MONITORID , ushort LEVEL ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 638;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 1) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 640;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( LEVEL >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( LEVEL <= 100 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 642;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , (ushort)( MONITORID ), "BRI", Functions.Chr( (int)( LEVEL ) )) ) ; 
                __context__.SourceCodeLine = 643;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETBACKLIGHT (  SplusExecutionContext __context__, ushort MONITORID ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 652;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , (ushort)( MONITORID ), "BRI") ) ; 
        __context__.SourceCodeLine = 653;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void GETCURRENTSTATUSALL (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 662;
        GETPOWER (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        __context__.SourceCodeLine = 663;
        GETINPUT (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        __context__.SourceCodeLine = 664;
        GETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        __context__.SourceCodeLine = 665;
        GETVOLUMEMUTE (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        __context__.SourceCodeLine = 666;
        GETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        __context__.SourceCodeLine = 667;
        GETWAKEMODE (  __context__ , (ushort)( MONITOR_ID  .Value )) ; 
        
        }
        
    private void SENDPOLL (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 672;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISPOLLING == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 1) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 674;
            /* Trace( "sendPoll()") */ ; 
            __context__.SourceCodeLine = 676;
            GETCURRENTSTATUSALL (  __context__  ) ; 
            __context__.SourceCodeLine = 678;
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
            __context__.SourceCodeLine = 679;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 1))  ) ) 
                {
                __context__.SourceCodeLine = 680;
                SENDPOLL (  __context__  ) ; 
                }
            
            }
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void STARTPOLL (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 686;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 688;
        UMODULE . NISPOLLING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 689;
        IS_POLLING  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 690;
        SENDPOLL (  __context__  ) ; 
        } 
    
    
    }
    
private void STOPPOLL (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 696;
    UMODULE . NISPOLLING = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 697;
    IS_POLLING  .Value = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 698;
    CancelWait ( "POLL" ) ; 
    
    }
    
private ushort ISINITIALIZED (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 707;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 65535) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NINPUT == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NVOLUMELEVEL == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NVOLUMEMUTE == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NWAKEMODE == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NBACKLIGHTLEVEL == 65535) )) ))  ) ) 
        {
        __context__.SourceCodeLine = 709;
        return (ushort)( 0) ; 
        }
    
    __context__.SourceCodeLine = 711;
    return (ushort)( 1) ; 
    
    }
    
private void GETINITIALIZED (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 716;
    /* Trace( "getInitialized()") */ ; 
    __context__.SourceCodeLine = 718;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISINITIALIZING == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (ISINITIALIZED( __context__ ) == 0) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 720;
        /* Trace( "passed test") */ ; 
        __context__.SourceCodeLine = 722;
        UMODULE . NISINITIALIZING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 723;
        GETCURRENTSTATUSALL (  __context__  ) ; 
        } 
    
    
    }
    
private void GOODRESPONSE (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 733;
    /* Trace( "goodResponse()") */ ; 
    __context__.SourceCodeLine = 735;
    UMODULE . NISCOMMUNICATING = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 736;
    IS_COMMUNICATING  .Value = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 738;
    UQUEUE . NSTRIKECOUNT = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 740;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NLASTOUTWASHEARTBEAT == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 1) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISINITIALIZING == 0) )) ))  ) ) 
        {
        __context__.SourceCodeLine = 741;
        GETINITIALIZED (  __context__  ) ; 
        }
    
    __context__.SourceCodeLine = 743;
    UQUEUE . NBUSY = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 745;
    SENDNEXTQUEUEITEM (  __context__  ) ; 
    
    }
    
private void PROCESSDEVICEMSG (  SplusExecutionContext __context__ ) 
    { 
    CrestronString SSTATUS;
    SSTATUS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    ushort NSTATUS = 0;
    
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 754;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( UMODULE.SLASTMSGIN ) > 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 756;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "\u0008" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 758;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "POW" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 760;
                SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "POW", "\u0008")  ) ; 
                __context__.SourceCodeLine = 762;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0001"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 764;
                    UDEVICE . NPOWER = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 765;
                    POWER_IS_ON  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 767;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0000"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 769;
                        UDEVICE . NPOWER = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 770;
                        POWER_IS_ON  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 773;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "VOL" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 775;
                    NSTATUS = (ushort) ( Byte( UMODULE.SLASTMSGIN , (int)( 7 ) ) ) ; 
                    __context__.SourceCodeLine = 777;
                    UDEVICE . NVOLUMELEVEL = (ushort) ( NSTATUS ) ; 
                    __context__.SourceCodeLine = 778;
                    VOLUME_LEVEL  .Value = (ushort) ( NSTATUS ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 780;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "MUT" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 782;
                        SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "MUT", "\u0008")  ) ; 
                        __context__.SourceCodeLine = 784;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0001"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 786;
                            UDEVICE . NVOLUMEMUTE = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 787;
                            VOLUME_IS_MUTED  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 789;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0000"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 791;
                                UDEVICE . NVOLUMEMUTE = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 792;
                                VOLUME_IS_MUTED  .Value = (ushort) ( 0 ) ; 
                                } 
                            
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 795;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "BRI" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 797;
                            NSTATUS = (ushort) ( Byte( UMODULE.SLASTMSGIN , (int)( 7 ) ) ) ; 
                            __context__.SourceCodeLine = 799;
                            UDEVICE . NBACKLIGHTLEVEL = (ushort) ( NSTATUS ) ; 
                            __context__.SourceCodeLine = 800;
                            BACKLIGHT_LEVEL  .Value = (ushort) ( NSTATUS ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 802;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "MIN" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 804;
                                SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "MIN", "\u0008")  ) ; 
                                __context__.SourceCodeLine = 806;
                                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                ushort __FN_FOREND_VAL__1 = (ushort)4; 
                                int __FN_FORSTEP_VAL__1 = (int)1; 
                                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                                    { 
                                    __context__.SourceCodeLine = 808;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SINPUTCOMMANDS[ I ]))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 810;
                                        UDEVICE . NINPUT = (ushort) ( I ) ; 
                                        __context__.SourceCodeLine = 811;
                                        INPUTS_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 814;
                                        INPUTS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 806;
                                    } 
                                
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 817;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "WFS" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 819;
                                    SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "WFS", "\u0008")  ) ; 
                                    __context__.SourceCodeLine = 821;
                                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__2 = (ushort)3; 
                                    int __FN_FORSTEP_VAL__2 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                        { 
                                        __context__.SourceCodeLine = 823;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SWAKEMODECOMMANDS[ I ]))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 825;
                                            UDEVICE . NWAKEMODE = (ushort) ( I ) ; 
                                            __context__.SourceCodeLine = 826;
                                            WAKE_MODES_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 829;
                                            WAKE_MODES_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 821;
                                        } 
                                    
                                    } 
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 833;
            CancelWait ( "QUEUEFALSERESPONSE" ) ; 
            __context__.SourceCodeLine = 834;
            GOODRESPONSE (  __context__  ) ; 
            __context__.SourceCodeLine = 836;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISINITIALIZING == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (ISINITIALIZED( __context__ ) == 1) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 838;
                /* Trace( "initialization complete") */ ; 
                __context__.SourceCodeLine = 840;
                UMODULE . NISINITIALIZING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 841;
                UMODULE . NISINITIALIZED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 842;
                IS_INITIALIZED  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 844;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (POLL_ENABLE  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISPOLLING == 0) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 845;
                    CreateWait ( "STARTPOLLINGPROCESS" , 2000 , STARTPOLLINGPROCESS_Callback ) ;
                    }
                
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
            __context__.SourceCodeLine = 846;
            STARTPOLL (  __context__  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void SENDHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    CrestronString SCOMMAND;
    SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    
    __context__.SourceCodeLine = 860;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISHEARTBEATING == 1))  ) ) 
        { 
        __context__.SourceCodeLine = 862;
        if ( Functions.TestForTrue  ( ( ISQUEUEEMPTY( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 864;
            /* Trace( "sendHeartbeat()") */ ; 
            __context__.SourceCodeLine = 866;
            MakeString ( SCOMMAND , "<HEARTBEAT>{0}", BUILDGETMSG (  __context__ , (ushort)( MONITOR_ID  .Value ), "POW") ) ; 
            __context__.SourceCodeLine = 867;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
            } 
        
        __context__.SourceCodeLine = 871;
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
            __context__.SourceCodeLine = 872;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISHEARTBEATING == 1))  ) ) 
                {
                __context__.SourceCodeLine = 873;
                SENDHEARTBEAT (  __context__  ) ; 
                }
            
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void STARTHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 879;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISHEARTBEATING == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 881;
        UMODULE . NISHEARTBEATING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 882;
        SENDHEARTBEAT (  __context__  ) ; 
        } 
    
    
    }
    
private void STOPHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 888;
    UMODULE . NISHEARTBEATING = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 889;
    CancelWait ( "HEARTBEAT" ) ; 
    
    }
    
private void DOCONNECT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 898;
    /* Trace( "doConnect()") */ ; 
    __context__.SourceCodeLine = 900;
    RESET (  __context__  ) ; 
    __context__.SourceCodeLine = 901;
    CancelWait ( "QUEUEFALSERESPONSE" ) ; 
    __context__.SourceCodeLine = 903;
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
            __context__.SourceCodeLine = 904;
            STARTHEARTBEAT (  __context__  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void DODISCONNECT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 909;
    /* Trace( "doDisconnect()") */ ; 
    __context__.SourceCodeLine = 911;
    RESET (  __context__  ) ; 
    __context__.SourceCodeLine = 912;
    CancelWait ( "STARTHEARTBEATPROCESS" ) ; 
    __context__.SourceCodeLine = 913;
    CancelWait ( "STARTPOLLINGPROCESS" ) ; 
    __context__.SourceCodeLine = 914;
    CancelWait ( "QUEUEFALSERESPONSE" ) ; 
    __context__.SourceCodeLine = 915;
    STOPHEARTBEAT (  __context__  ) ; 
    __context__.SourceCodeLine = 916;
    STOPPOLL (  __context__  ) ; 
    
    }
    
private void DOREINITIALIZE (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 921;
    /* Trace( "doReinitialize()") */ ; 
    __context__.SourceCodeLine = 923;
    DODISCONNECT (  __context__  ) ; 
    __context__.SourceCodeLine = 924;
    DOCONNECT (  __context__  ) ; 
    
    }
    
object CONNECT_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 934;
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
        
        __context__.SourceCodeLine = 939;
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
        
        __context__.SourceCodeLine = 944;
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
        
        __context__.SourceCodeLine = 949;
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
        
        __context__.SourceCodeLine = 954;
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
        
        __context__.SourceCodeLine = 959;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NPOWER == 1))  ) ) 
            {
            __context__.SourceCodeLine = 960;
            SETPOWER (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 961;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NPOWER == 0))  ) ) 
                {
                __context__.SourceCodeLine = 962;
                SETPOWER (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 1 )) ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_UP_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 967;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NVOLUMELEVEL < 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 969;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (100 - UDEVICE.NVOLUMELEVEL) > VOLUME_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 970;
                SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NVOLUMELEVEL + VOLUME_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 972;
                SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 100 )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_DOWN_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 978;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NVOLUMELEVEL > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 980;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (UDEVICE.NVOLUMELEVEL - 0) > VOLUME_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 981;
                SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NVOLUMELEVEL - VOLUME_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 983;
                SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_SET_OnChange_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 989;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VOLUME_SET  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VOLUME_SET  .UshortValue <= 100 ) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 990;
            SETVOLUME (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( VOLUME_SET  .UshortValue )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_MUTE_ON_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 995;
        SETVOLUMEMUTE (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_MUTE_OFF_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1000;
        SETVOLUMEMUTE (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VOLUME_MUTE_TOGGLE_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1005;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NVOLUMEMUTE == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1006;
            SETVOLUMEMUTE (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1007;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NVOLUMEMUTE == 0))  ) ) 
                {
                __context__.SourceCodeLine = 1008;
                SETVOLUMEMUTE (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 1 )) ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACKLIGHT_UP_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1013;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NBACKLIGHTLEVEL < 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1015;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (100 - UDEVICE.NBACKLIGHTLEVEL) > BACKLIGHT_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1016;
                SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NBACKLIGHTLEVEL + BACKLIGHT_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1018;
                SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 100 )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACKLIGHT_DOWN_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1024;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NBACKLIGHTLEVEL > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1026;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (UDEVICE.NBACKLIGHTLEVEL - 0) > BACKLIGHT_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1027;
                SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NBACKLIGHTLEVEL - BACKLIGHT_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1029;
                SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 0 )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object BACKLIGHT_SET_OnChange_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1035;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( BACKLIGHT_SET  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( BACKLIGHT_SET  .UshortValue <= 100 ) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1036;
            SETBACKLIGHT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( BACKLIGHT_SET  .UshortValue )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUTS_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INPUT = 0;
        
        
        __context__.SourceCodeLine = 1042;
        INPUT = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1044;
        SETINPUT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( INPUT )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object INPUT_CYCLE_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1049;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NINPUT != 65535))  ) ) 
            { 
            __context__.SourceCodeLine = 1051;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NINPUT == 4))  ) ) 
                {
                __context__.SourceCodeLine = 1052;
                SETINPUT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 1 )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1054;
                SETINPUT (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NINPUT + 1) )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object WAKE_MODES_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort MODE = 0;
        
        
        __context__.SourceCodeLine = 1062;
        MODE = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1064;
        SETWAKEMODE (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( MODE )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object WAKE_MODE_CYCLE_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1069;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NWAKEMODE != 65535))  ) ) 
            { 
            __context__.SourceCodeLine = 1071;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NWAKEMODE == 3))  ) ) 
                {
                __context__.SourceCodeLine = 1072;
                SETWAKEMODE (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( 1 )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1074;
                SETWAKEMODE (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( (UDEVICE.NWAKEMODE + 1) )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REMOTE_COMMANDS_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IRFUNCTION = 0;
        
        
        __context__.SourceCodeLine = 1081;
        IRFUNCTION = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1083;
        SENDIR (  __context__ , (ushort)( MONITOR_ID  .Value ), (ushort)( IRFUNCTION )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_ENABLE_OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1088;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 0))  ) ) 
            {
            __context__.SourceCodeLine = 1089;
            STARTPOLL (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_ENABLE_OnRelease_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1094;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1095;
            STOPPOLL (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_DEVICE_OnChange_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString MSGTOCMDEND;
        MSGTOCMDEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString MSGREMAINDER;
        MSGREMAINDER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 1104;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 1106;
            try 
                { 
                __context__.SourceCodeLine = 1108;
                MSGTOCMDEND  .UpdateValue ( Functions.Gather ( 6, FROM_DEVICE )  ) ; 
                __context__.SourceCodeLine = 1111;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "GVE" , MSGTOCMDEND ) == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 1112;
                    MSGREMAINDER  .UpdateValue ( Functions.Gather ( 7, FROM_DEVICE )  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1115;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (CONTAINS( __context__ , "SER" , MSGTOCMDEND ) == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (CONTAINS( __context__ , "MNA" , MSGTOCMDEND ) == 1) )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1116;
                        MSGREMAINDER  .UpdateValue ( Functions.Gather ( 14, FROM_DEVICE )  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1120;
                        MSGREMAINDER  .UpdateValue ( Functions.Gather ( 2, FROM_DEVICE )  ) ; 
                        }
                    
                    }
                
                __context__.SourceCodeLine = 1122;
                MakeString ( UMODULE . SLASTMSGIN , "{0}{1}", MSGTOCMDEND , MSGREMAINDER ) ; 
                __context__.SourceCodeLine = 1123;
                PROCESSDEVICEMSG (  __context__  ) ; 
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 1127;
                /* Trace( "Issue with Device message handling\r\n") */ ; 
                
                }
                
                __context__.SourceCodeLine = 1104;
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
        
        __context__.SourceCodeLine = 1174;
        SINPUTCOMMANDS [ 1 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1175;
        SINPUTCOMMANDS [ 2 ]  .UpdateValue ( "\u0001"  ) ; 
        __context__.SourceCodeLine = 1176;
        SINPUTCOMMANDS [ 3 ]  .UpdateValue ( "\u0009"  ) ; 
        __context__.SourceCodeLine = 1177;
        SINPUTCOMMANDS [ 4 ]  .UpdateValue ( "\u000D"  ) ; 
        __context__.SourceCodeLine = 1179;
        SWAKEMODECOMMANDS [ 1 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1180;
        SWAKEMODECOMMANDS [ 2 ]  .UpdateValue ( "\u0001"  ) ; 
        __context__.SourceCodeLine = 1181;
        SWAKEMODECOMMANDS [ 3 ]  .UpdateValue ( "\u0002"  ) ; 
        __context__.SourceCodeLine = 1183;
        SREMOTECOMMANDS [ 1 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1184;
        SREMOTECOMMANDS [ 2 ]  .UpdateValue ( "\u0001"  ) ; 
        __context__.SourceCodeLine = 1185;
        SREMOTECOMMANDS [ 3 ]  .UpdateValue ( "\u0002"  ) ; 
        __context__.SourceCodeLine = 1186;
        SREMOTECOMMANDS [ 4 ]  .UpdateValue ( "\u0003"  ) ; 
        __context__.SourceCodeLine = 1187;
        SREMOTECOMMANDS [ 5 ]  .UpdateValue ( "\u0004"  ) ; 
        __context__.SourceCodeLine = 1188;
        SREMOTECOMMANDS [ 6 ]  .UpdateValue ( "\u0005"  ) ; 
        __context__.SourceCodeLine = 1189;
        SREMOTECOMMANDS [ 7 ]  .UpdateValue ( "\u0006"  ) ; 
        __context__.SourceCodeLine = 1190;
        SREMOTECOMMANDS [ 8 ]  .UpdateValue ( "\u0007"  ) ; 
        __context__.SourceCodeLine = 1192;
        UMODULE . NISHEARTBEATING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1193;
        UMODULE . NISPOLLING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1195;
        RESET (  __context__  ) ; 
        __context__.SourceCodeLine = 1197;
        WaitForInitializationComplete ( ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    SCOMMANDQUEUE  = new CrestronString[ 51 ];
    for( uint i = 0; i < 51; i++ )
        SCOMMANDQUEUE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    SSTATUSQUEUE  = new CrestronString[ 51 ];
    for( uint i = 0; i < 51; i++ )
        SSTATUSQUEUE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    SINPUTCOMMANDS  = new CrestronString[ 5 ];
    for( uint i = 0; i < 5; i++ )
        SINPUTCOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SWAKEMODECOMMANDS  = new CrestronString[ 4 ];
    for( uint i = 0; i < 4; i++ )
        SWAKEMODECOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SREMOTECOMMANDS  = new CrestronString[ 9 ];
    for( uint i = 0; i < 9; i++ )
        SREMOTECOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
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
    
    WAKE_MODE_CYCLE = new Crestron.Logos.SplusObjects.DigitalInput( WAKE_MODE_CYCLE__DigitalInput__, this );
    m_DigitalInputList.Add( WAKE_MODE_CYCLE__DigitalInput__, WAKE_MODE_CYCLE );
    
    INPUTS = new InOutArray<DigitalInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        INPUTS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( INPUTS__DigitalInput__ + i, INPUTS__DigitalInput__, this );
        m_DigitalInputList.Add( INPUTS__DigitalInput__ + i, INPUTS[i+1] );
    }
    
    WAKE_MODES = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        WAKE_MODES[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( WAKE_MODES__DigitalInput__ + i, WAKE_MODES__DigitalInput__, this );
        m_DigitalInputList.Add( WAKE_MODES__DigitalInput__ + i, WAKE_MODES[i+1] );
    }
    
    REMOTE_COMMANDS = new InOutArray<DigitalInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        REMOTE_COMMANDS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( REMOTE_COMMANDS__DigitalInput__ + i, REMOTE_COMMANDS__DigitalInput__, this );
        m_DigitalInputList.Add( REMOTE_COMMANDS__DigitalInput__ + i, REMOTE_COMMANDS[i+1] );
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
    
    INPUTS_FB = new InOutArray<DigitalOutput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        INPUTS_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( INPUTS_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( INPUTS_FB__DigitalOutput__ + i, INPUTS_FB[i+1] );
    }
    
    WAKE_MODES_FB = new InOutArray<DigitalOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        WAKE_MODES_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( WAKE_MODES_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( WAKE_MODES_FB__DigitalOutput__ + i, WAKE_MODES_FB[i+1] );
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
    VOLUME_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_UP_OnPush_6, false ) );
    VOLUME_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_DOWN_OnPush_7, false ) );
    VOLUME_SET.OnAnalogChange.Add( new InputChangeHandlerWrapper( VOLUME_SET_OnChange_8, false ) );
    VOLUME_MUTE_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_MUTE_ON_OnPush_9, false ) );
    VOLUME_MUTE_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_MUTE_OFF_OnPush_10, false ) );
    VOLUME_MUTE_TOGGLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( VOLUME_MUTE_TOGGLE_OnPush_11, false ) );
    BACKLIGHT_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( BACKLIGHT_UP_OnPush_12, false ) );
    BACKLIGHT_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( BACKLIGHT_DOWN_OnPush_13, false ) );
    BACKLIGHT_SET.OnAnalogChange.Add( new InputChangeHandlerWrapper( BACKLIGHT_SET_OnChange_14, false ) );
    for( uint i = 0; i < 4; i++ )
        INPUTS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( INPUTS_OnPush_15, false ) );
        
    INPUT_CYCLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INPUT_CYCLE_OnPush_16, false ) );
    for( uint i = 0; i < 3; i++ )
        WAKE_MODES[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( WAKE_MODES_OnPush_17, false ) );
        
    WAKE_MODE_CYCLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( WAKE_MODE_CYCLE_OnPush_18, false ) );
    for( uint i = 0; i < 8; i++ )
        REMOTE_COMMANDS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( REMOTE_COMMANDS_OnPush_19, false ) );
        
    POLL_ENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnPush_20, false ) );
    POLL_ENABLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnRelease_21, false ) );
    FROM_DEVICE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE_OnChange_22, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PLANAR_PS_SERIES__PS4661T_PS5561T__V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


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
const uint WAKE_MODE_CYCLE__DigitalInput__ = 15;
const uint INPUTS__DigitalInput__ = 16;
const uint WAKE_MODES__DigitalInput__ = 20;
const uint REMOTE_COMMANDS__DigitalInput__ = 23;
const uint VOLUME_SET__AnalogSerialInput__ = 0;
const uint BACKLIGHT_SET__AnalogSerialInput__ = 1;
const uint FROM_DEVICE__AnalogSerialInput__ = 2;
const uint IS_COMMUNICATING__DigitalOutput__ = 0;
const uint IS_INITIALIZED__DigitalOutput__ = 1;
const uint POWER_IS_ON__DigitalOutput__ = 2;
const uint VOLUME_IS_MUTED__DigitalOutput__ = 3;
const uint IS_POLLING__DigitalOutput__ = 4;
const uint INPUTS_FB__DigitalOutput__ = 5;
const uint WAKE_MODES_FB__DigitalOutput__ = 9;
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
    public ushort  NLASTOUTWASHEARTBEAT = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  NISPOLLING = 0;
    
    [SplusStructAttribute(7, false, false)]
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
    public ushort  NVOLUMEMUTE = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  NBACKLIGHTLEVEL = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  NWAKEMODE = 0;
    
    
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
