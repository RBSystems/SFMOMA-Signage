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

namespace UserModule_PLANAR_EP_SERIES_4K_V1_0
{
    public class UserModuleClass_PLANAR_EP_SERIES_4K_V1_0 : SplusObject
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
        Crestron.Logos.SplusObjects.DigitalInput MESSAGE_BOX_ON;
        Crestron.Logos.SplusObjects.DigitalInput MESSAGE_BOX_OFF;
        Crestron.Logos.SplusObjects.DigitalInput MESSAGE_BOX_TOGGLE;
        Crestron.Logos.SplusObjects.DigitalInput POLL_ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput VIDEO_INPUT_CYCLE;
        Crestron.Logos.SplusObjects.DigitalInput MULTISOURCE_VIEWS_CYCLE;
        Crestron.Logos.SplusObjects.DigitalInput POWER_SAVE_CONFIGS_CYCLE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> VIDEO_INPUTS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> AUDIO_INPUTS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MULTISOURCE_VIEWS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MULTISOURCE_SELECT_2;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MULTISOURCE_SELECT_3;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MULTISOURCE_SELECT_4;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> MULTISOURCE_PRESETS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> POWER_SAVE_CONFIGS;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> REMOTE_COMMANDS;
        Crestron.Logos.SplusObjects.AnalogInput VOLUME_SET;
        Crestron.Logos.SplusObjects.AnalogInput BACKLIGHT_SET;
        Crestron.Logos.SplusObjects.BufferInput FROM_DEVICE;
        Crestron.Logos.SplusObjects.DigitalOutput IS_COMMUNICATING;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.DigitalOutput POWER_IS_ON;
        Crestron.Logos.SplusObjects.DigitalOutput VOLUME_IS_MUTED;
        Crestron.Logos.SplusObjects.DigitalOutput MESSAGE_BOX_IS_ON;
        Crestron.Logos.SplusObjects.DigitalOutput IS_POLLING;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> VIDEO_INPUTS_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> AUDIO_INPUTS_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MULTISOURCE_VIEWS_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MULTISOURCE_SELECT_2_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MULTISOURCE_SELECT_3_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MULTISOURCE_SELECT_4_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> MULTISOURCE_PRESETS_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> POWER_SAVE_CONFIGS_FB;
        Crestron.Logos.SplusObjects.AnalogOutput VOLUME_LEVEL;
        Crestron.Logos.SplusObjects.AnalogOutput BACKLIGHT_LEVEL;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE;
        UShortParameter VOLUME_STEP_SIZE;
        UShortParameter BACKLIGHT_STEP_SIZE;
        _MODULESTATUS UMODULE;
        _DEVICESTATUS UDEVICE;
        _QUEUE UQUEUE;
        CrestronString [] SCOMMANDQUEUE;
        CrestronString [] SSTATUSQUEUE;
        CrestronString [] SVIDEOINPUTCOMMANDS;
        CrestronString [] SAUDIOINPUTCOMMANDS;
        CrestronString [] SMSVIEWCOMMANDS;
        CrestronString [] SMSPRESETCOMMANDS;
        CrestronString [] SPSCONFIGCOMMANDS;
        CrestronString [] SREMOTECOMMANDS;
        private ushort CONTAINS (  SplusExecutionContext __context__, CrestronString MATCHSTRING , CrestronString SOURCESTRING ) 
            { 
            
            __context__.SourceCodeLine = 267;
            return (ushort)( Functions.BoolToInt ( Functions.Find( MATCHSTRING , SOURCESTRING ) > 0 )) ; 
            
            }
            
        private CrestronString GETBOUNDSTRING (  SplusExecutionContext __context__, CrestronString SOURCE , CrestronString STARTSTRING , CrestronString ENDSTRING ) 
            { 
            ushort STARTINDEX = 0;
            
            ushort ENDINDEX = 0;
            
            CrestronString RESPONSE;
            RESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 276;
            RESPONSE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 278;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOURCE ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 280;
                STARTINDEX = (ushort) ( Functions.Find( STARTSTRING , SOURCE ) ) ; 
                __context__.SourceCodeLine = 281;
                ENDINDEX = (ushort) ( Functions.Find( ENDSTRING , SOURCE , (STARTINDEX + 1) ) ) ; 
                __context__.SourceCodeLine = 283;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX < ENDINDEX ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 285;
                    STARTINDEX = (ushort) ( (STARTINDEX + Functions.Length( STARTSTRING )) ) ; 
                    __context__.SourceCodeLine = 286;
                    RESPONSE  .UpdateValue ( Functions.Mid ( SOURCE ,  (int) ( STARTINDEX ) ,  (int) ( (ENDINDEX - STARTINDEX) ) )  ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 290;
            return ( RESPONSE ) ; 
            
            }
            
        private CrestronString BUILDSETMSG (  SplusExecutionContext __context__, CrestronString COMMAND , CrestronString VALUE ) 
            { 
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 301;
            MakeString ( MSG , "{0}{1}", MSG , "\u0007" ) ; 
            __context__.SourceCodeLine = 302;
            MakeString ( MSG , "{0}{1}", MSG , "\u0001" ) ; 
            __context__.SourceCodeLine = 303;
            MakeString ( MSG , "{0}{1}", MSG , "\u0002" ) ; 
            __context__.SourceCodeLine = 304;
            MakeString ( MSG , "{0}{1}", MSG , COMMAND ) ; 
            __context__.SourceCodeLine = 305;
            MakeString ( MSG , "{0}{1}", MSG , VALUE ) ; 
            __context__.SourceCodeLine = 306;
            MakeString ( MSG , "{0}{1}", MSG , "\u0008" ) ; 
            __context__.SourceCodeLine = 308;
            return ( MSG ) ; 
            
            }
            
        private CrestronString BUILDGETMSG (  SplusExecutionContext __context__, CrestronString COMMAND ) 
            { 
            CrestronString MSG;
            MSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 315;
            MakeString ( MSG , "{0}{1}", MSG , "\u0007" ) ; 
            __context__.SourceCodeLine = 316;
            MakeString ( MSG , "{0}{1}", MSG , "\u0001" ) ; 
            __context__.SourceCodeLine = 317;
            MakeString ( MSG , "{0}{1}", MSG , "\u0001" ) ; 
            __context__.SourceCodeLine = 318;
            MakeString ( MSG , "{0}{1}", MSG , COMMAND ) ; 
            __context__.SourceCodeLine = 319;
            MakeString ( MSG , "{0}{1}", MSG , "\u0008" ) ; 
            __context__.SourceCodeLine = 321;
            return ( MSG ) ; 
            
            }
            
        private void RESETQUEUE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 330;
            UQUEUE . NBUSY = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 331;
            UQUEUE . NHASITEMS = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 332;
            UQUEUE . NCOMMANDHEAD = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 333;
            UQUEUE . NCOMMANDTAIL = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 334;
            UQUEUE . NSTATUSHEAD = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 335;
            UQUEUE . NSTATUSTAIL = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 336;
            UQUEUE . NSTRIKECOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 337;
            UQUEUE . SLASTMSGOUT  .UpdateValue ( ""  ) ; 
            
            }
            
        private void RESETMODULE (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 342;
            UMODULE . NISCOMMUNICATING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 343;
            UMODULE . NISINITIALIZING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 344;
            UMODULE . NISINITIALIZED = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 345;
            UMODULE . NISPARSING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 346;
            UMODULE . NISPOLLING = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 347;
            UMODULE . SLASTMSGIN  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 349;
            IS_COMMUNICATING  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 350;
            IS_INITIALIZED  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RESETDEVICE (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 357;
            UDEVICE . NPOWER = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 358;
            UDEVICE . NVIDEOINPUT = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 359;
            UDEVICE . NAUDIOINPUT = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 360;
            UDEVICE . NVOLUMELEVEL = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 361;
            UDEVICE . NVOLUMEMUTE = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 362;
            UDEVICE . NBACKLIGHTLEVEL = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 363;
            UDEVICE . NMSVIEW = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 364;
            UDEVICE . NMSSELECT2 = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 365;
            UDEVICE . NMSSELECT3 = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 366;
            UDEVICE . NMSSELECT4 = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 367;
            UDEVICE . NPSCONFIG = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 368;
            UDEVICE . NMESSAGEBOX = (ushort) ( 65535 ) ; 
            __context__.SourceCodeLine = 370;
            POWER_IS_ON  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 371;
            VOLUME_IS_MUTED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 372;
            MESSAGE_BOX_IS_ON  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 373;
            VOLUME_LEVEL  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 374;
            BACKLIGHT_LEVEL  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 376;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)7; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                {
                __context__.SourceCodeLine = 377;
                VIDEO_INPUTS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 376;
                }
            
            __context__.SourceCodeLine = 379;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)7; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                {
                __context__.SourceCodeLine = 380;
                AUDIO_INPUTS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 379;
                }
            
            __context__.SourceCodeLine = 382;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)8; 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                {
                __context__.SourceCodeLine = 383;
                MULTISOURCE_VIEWS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 382;
                }
            
            __context__.SourceCodeLine = 385;
            ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__4 = (ushort)7; 
            int __FN_FORSTEP_VAL__4 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                {
                __context__.SourceCodeLine = 386;
                MULTISOURCE_SELECT_2_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 385;
                }
            
            __context__.SourceCodeLine = 388;
            ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__5 = (ushort)7; 
            int __FN_FORSTEP_VAL__5 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                {
                __context__.SourceCodeLine = 389;
                MULTISOURCE_SELECT_3_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 388;
                }
            
            __context__.SourceCodeLine = 391;
            ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__6 = (ushort)7; 
            int __FN_FORSTEP_VAL__6 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                {
                __context__.SourceCodeLine = 392;
                MULTISOURCE_SELECT_4_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 391;
                }
            
            __context__.SourceCodeLine = 394;
            ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__7 = (ushort)4; 
            int __FN_FORSTEP_VAL__7 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                {
                __context__.SourceCodeLine = 395;
                MULTISOURCE_PRESETS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 394;
                }
            
            __context__.SourceCodeLine = 397;
            ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__8 = (ushort)3; 
            int __FN_FORSTEP_VAL__8 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (I  >= __FN_FORSTART_VAL__8) && (I  <= __FN_FOREND_VAL__8) ) : ( (I  <= __FN_FORSTART_VAL__8) && (I  >= __FN_FOREND_VAL__8) ) ; I  += (ushort)__FN_FORSTEP_VAL__8) 
                {
                __context__.SourceCodeLine = 398;
                POWER_SAVE_CONFIGS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 397;
                }
            
            
            }
            
        private void RESET (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 403;
            Trace( "reset") ; 
            __context__.SourceCodeLine = 405;
            RESETQUEUE (  __context__  ) ; 
            __context__.SourceCodeLine = 406;
            RESETMODULE (  __context__  ) ; 
            __context__.SourceCodeLine = 407;
            RESETDEVICE (  __context__  ) ; 
            
            }
            
        private ushort ISQUEUEEMPTY (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 416;
            return (ushort)( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NHASITEMS == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NBUSY == 0) )) )) ; 
            
            }
            
        private CrestronString DEQUEUE (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SCMD;
            SCMD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 423;
            SCMD  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 425;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NHASITEMS == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NBUSY == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 427;
                UQUEUE . NBUSY = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 430;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDHEAD != UQUEUE.NCOMMANDTAIL))  ) ) 
                    { 
                    __context__.SourceCodeLine = 432;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDTAIL == Functions.GetNumArrayRows( SCOMMANDQUEUE )))  ) ) 
                        {
                        __context__.SourceCodeLine = 433;
                        UQUEUE . NCOMMANDTAIL = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 435;
                        UQUEUE . NCOMMANDTAIL = (ushort) ( (UQUEUE.NCOMMANDTAIL + 1) ) ; 
                        }
                    
                    __context__.SourceCodeLine = 437;
                    UQUEUE . SLASTMSGOUT  .UpdateValue ( SCOMMANDQUEUE [ UQUEUE.NCOMMANDTAIL ]  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 440;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSHEAD != UQUEUE.NSTATUSTAIL))  ) ) 
                        { 
                        __context__.SourceCodeLine = 442;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSTAIL == Functions.GetNumArrayRows( SSTATUSQUEUE )))  ) ) 
                            {
                            __context__.SourceCodeLine = 443;
                            UQUEUE . NSTATUSTAIL = (ushort) ( 1 ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 445;
                            UQUEUE . NSTATUSTAIL = (ushort) ( (UQUEUE.NSTATUSTAIL + 1) ) ; 
                            }
                        
                        __context__.SourceCodeLine = 447;
                        UQUEUE . SLASTMSGOUT  .UpdateValue ( SSTATUSQUEUE [ UQUEUE.NSTATUSTAIL ]  ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 450;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NCOMMANDHEAD == UQUEUE.NCOMMANDTAIL) ) && Functions.TestForTrue ( Functions.BoolToInt (UQUEUE.NSTATUSHEAD == UQUEUE.NSTATUSTAIL) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 451;
                    UQUEUE . NHASITEMS = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 453;
                SCMD  .UpdateValue ( UQUEUE . SLASTMSGOUT  ) ; 
                } 
            
            __context__.SourceCodeLine = 456;
            return ( SCMD ) ; 
            
            }
            
        private void SENDNEXTQUEUEITEM (  SplusExecutionContext __context__ ) 
            { 
            CrestronString SOUTGOING;
            SOUTGOING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            
            __context__.SourceCodeLine = 463;
            SOUTGOING  .UpdateValue ( DEQUEUE (  __context__  )  ) ; 
            __context__.SourceCodeLine = 465;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOUTGOING ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 467;
                Trace( "sendNextQueueItem() - sending next message") ; 
                __context__.SourceCodeLine = 469;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "GVE" , SOUTGOING ) == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 470;
                    UMODULE . NLASTOUTWASHEARTBEAT = (ushort) ( 1 ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 472;
                    UMODULE . NLASTOUTWASHEARTBEAT = (ushort) ( 0 ) ; 
                    }
                
                __context__.SourceCodeLine = 474;
                MakeString ( TO_DEVICE , "{0}", SOUTGOING ) ; 
                __context__.SourceCodeLine = 476;
                CreateWait ( "QUEUEFALSERESPONSE" , 250 , QUEUEFALSERESPONSE_Callback ) ;
                } 
            
            else 
                {
                __context__.SourceCodeLine = 499;
                Trace( "sendNextQueueItem() - nothing to send") ; 
                }
            
            
            }
            
        public void QUEUEFALSERESPONSE_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 478;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NBUSY == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 480;
                UQUEUE . NBUSY = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 482;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UQUEUE.NSTRIKECOUNT < 3 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 484;
                    UQUEUE . NSTRIKECOUNT = (ushort) ( (UQUEUE.NSTRIKECOUNT + 1) ) ; 
                    __context__.SourceCodeLine = 486;
                    Trace( "Failed Response") ; 
                    __context__.SourceCodeLine = 487;
                    Trace( "Strike Count[{0:d}]", (ushort)UQUEUE.NSTRIKECOUNT) ; 
                    __context__.SourceCodeLine = 491;
                    SENDNEXTQUEUEITEM (  __context__  ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 494;
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
        
        
        __context__.SourceCodeLine = 506;
        NQUEUEWASEMPTY = (ushort) ( ISQUEUEEMPTY( __context__ ) ) ; 
        __context__.SourceCodeLine = 508;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (BPRIORITY == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 510;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDHEAD == Functions.GetNumArrayRows( SCOMMANDQUEUE )))  ) ) 
                { 
                __context__.SourceCodeLine = 512;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDTAIL != 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 514;
                    UQUEUE . NCOMMANDHEAD = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 515;
                    SCOMMANDQUEUE [ UQUEUE.NCOMMANDHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 516;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 519;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NCOMMANDTAIL != (UQUEUE.NCOMMANDHEAD + 1)))  ) ) 
                    { 
                    __context__.SourceCodeLine = 521;
                    UQUEUE . NCOMMANDHEAD = (ushort) ( (UQUEUE.NCOMMANDHEAD + 1) ) ; 
                    __context__.SourceCodeLine = 522;
                    SCOMMANDQUEUE [ UQUEUE.NCOMMANDHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 523;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                }
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 528;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSHEAD == Functions.GetNumArrayRows( SSTATUSQUEUE )))  ) ) 
                { 
                __context__.SourceCodeLine = 530;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSTAIL != 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 532;
                    UQUEUE . NSTATUSHEAD = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 533;
                    SSTATUSQUEUE [ UQUEUE.NSTATUSHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 534;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 537;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UQUEUE.NSTATUSTAIL != (UQUEUE.NSTATUSHEAD + 1)))  ) ) 
                    { 
                    __context__.SourceCodeLine = 539;
                    UQUEUE . NSTATUSHEAD = (ushort) ( (UQUEUE.NSTATUSHEAD + 1) ) ; 
                    __context__.SourceCodeLine = 540;
                    SSTATUSQUEUE [ UQUEUE.NSTATUSHEAD ]  .UpdateValue ( SCMD  ) ; 
                    __context__.SourceCodeLine = 541;
                    UQUEUE . NHASITEMS = (ushort) ( 1 ) ; 
                    } 
                
                }
            
            } 
        
        __context__.SourceCodeLine = 545;
        if ( Functions.TestForTrue  ( ( NQUEUEWASEMPTY)  ) ) 
            {
            __context__.SourceCodeLine = 546;
            SENDNEXTQUEUEITEM (  __context__  ) ; 
            }
        
        
        }
        
    private void SETPOWER (  SplusExecutionContext __context__, ushort STATE ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 557;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (STATE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (STATE == 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 559;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)STATE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 561;
                        MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "POW", "\u0001") ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                        {
                        __context__.SourceCodeLine = 562;
                        MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "POW", "\u0000") ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 565;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
            } 
        
        
        }
        
    private void GETPOWER (  SplusExecutionContext __context__ ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 573;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "POW") ) ; 
        __context__.SourceCodeLine = 574;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETVIDEOINPUT (  SplusExecutionContext __context__, ushort INPUT ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 581;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 583;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INPUT > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INPUT <= 7 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 585;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "MIN", SVIDEOINPUTCOMMANDS[ INPUT ]) ) ; 
                __context__.SourceCodeLine = 586;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETVIDEOINPUT (  SplusExecutionContext __context__ ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 595;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "MIN") ) ; 
        __context__.SourceCodeLine = 596;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETAUDIOINPUT (  SplusExecutionContext __context__, ushort INPUT ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 603;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 605;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INPUT > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INPUT <= 7 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 607;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "CAS", SAUDIOINPUTCOMMANDS[ INPUT ]) ) ; 
                __context__.SourceCodeLine = 608;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETAUDIOINPUT (  SplusExecutionContext __context__ ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 617;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "CAS") ) ; 
        __context__.SourceCodeLine = 618;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETVOLUME (  SplusExecutionContext __context__, ushort LEVEL ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 625;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 627;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( LEVEL >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( LEVEL <= 100 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 629;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "VOL", Functions.Chr( (int)( LEVEL ) )) ) ; 
                __context__.SourceCodeLine = 630;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETVOLUME (  SplusExecutionContext __context__ ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 639;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "VOL") ) ; 
        __context__.SourceCodeLine = 640;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETVOLUMEMUTE (  SplusExecutionContext __context__, ushort STATE ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 647;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 649;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (STATE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (STATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 651;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_2__ = ((int)STATE);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                            {
                            __context__.SourceCodeLine = 653;
                            MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "MUT", "\u0001") ) ; 
                            }
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 0) ) ) ) 
                            {
                            __context__.SourceCodeLine = 654;
                            MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "MUT", "\u0000") ) ; 
                            }
                        
                        } 
                        
                    }
                    
                
                __context__.SourceCodeLine = 657;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETVOLUMEMUTE (  SplusExecutionContext __context__ ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 666;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "MUT") ) ; 
        __context__.SourceCodeLine = 667;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETMULTISOURCEVIEW (  SplusExecutionContext __context__, ushort VIEW ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 674;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 676;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VIEW > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VIEW <= 8 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 678;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "PSC", SMSVIEWCOMMANDS[ VIEW ]) ) ; 
                __context__.SourceCodeLine = 679;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETMULTISOURCEVIEW (  SplusExecutionContext __context__ ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 688;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "PSC") ) ; 
        __context__.SourceCodeLine = 689;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETMULTISOURCESELECT (  SplusExecutionContext __context__, ushort WINDOW , ushort INPUT ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 696;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 698;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( WINDOW > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( WINDOW <= 3 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 700;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( INPUT > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( INPUT <= 7 ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 702;
                    
                        {
                        int __SPLS_TMPVAR__SWTCH_3__ = ((int)WINDOW);
                        
                            { 
                            if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                                {
                                __context__.SourceCodeLine = 704;
                                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "PIN", SVIDEOINPUTCOMMANDS[ INPUT ]) ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                                {
                                __context__.SourceCodeLine = 705;
                                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "PIO", SVIDEOINPUTCOMMANDS[ INPUT ]) ) ; 
                                }
                            
                            else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                                {
                                __context__.SourceCodeLine = 706;
                                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "PIP", SVIDEOINPUTCOMMANDS[ INPUT ]) ) ; 
                                }
                            
                            } 
                            
                        }
                        
                    
                    __context__.SourceCodeLine = 709;
                    ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                    } 
                
                } 
            
            } 
        
        
        }
        
    private void GETMULTISOURCESELECT (  SplusExecutionContext __context__, ushort WINDOW ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 719;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( WINDOW > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( WINDOW <= 3 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 721;
            
                {
                int __SPLS_TMPVAR__SWTCH_4__ = ((int)WINDOW);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 723;
                        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "PIN") ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                        {
                        __context__.SourceCodeLine = 724;
                        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "PIO") ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 3) ) ) ) 
                        {
                        __context__.SourceCodeLine = 725;
                        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "PIP") ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 728;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
            } 
        
        
        }
        
    private void SETMULTISOURCEPRESET (  SplusExecutionContext __context__, ushort PRESET ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 736;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 738;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( PRESET > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( PRESET <= 4 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 740;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "PRC", SMSPRESETCOMMANDS[ PRESET ]) ) ; 
                __context__.SourceCodeLine = 741;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void SETPOWERSAVECONFIG (  SplusExecutionContext __context__, ushort CONFIG ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 750;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 752;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( CONFIG > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( CONFIG <= 3 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 754;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "WFS", SPSCONFIGCOMMANDS[ CONFIG ]) ) ; 
                __context__.SourceCodeLine = 755;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETPOWERSAVECONFIG (  SplusExecutionContext __context__ ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 764;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "WFS") ) ; 
        __context__.SourceCodeLine = 765;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SENDIR (  SplusExecutionContext __context__, ushort IRFUNCTION ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 772;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 774;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IRFUNCTION > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( IRFUNCTION <= 36 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 776;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "RCU", SREMOTECOMMANDS[ IRFUNCTION ]) ) ; 
                __context__.SourceCodeLine = 777;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void SETBACKLIGHT (  SplusExecutionContext __context__, ushort LEVEL ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 786;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 788;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( LEVEL >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( LEVEL <= 100 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 790;
                MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "BRI", Functions.Chr( (int)( LEVEL ) )) ) ; 
                __context__.SourceCodeLine = 791;
                ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
                } 
            
            } 
        
        
        }
        
    private void GETBACKLIGHT (  SplusExecutionContext __context__ ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 800;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "BRI") ) ; 
        __context__.SourceCodeLine = 801;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void SETMESSAGEBOX (  SplusExecutionContext __context__, ushort STATE ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 808;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (STATE == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (STATE == 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 810;
            
                {
                int __SPLS_TMPVAR__SWTCH_5__ = ((int)STATE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 1) ) ) ) 
                        {
                        __context__.SourceCodeLine = 812;
                        MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "MSB", "\u0001") ) ; 
                        }
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_5__ == ( 0) ) ) ) 
                        {
                        __context__.SourceCodeLine = 813;
                        MakeString ( SCOMMAND , "{0}", BUILDSETMSG (  __context__ , "MSB", "\u0000") ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 816;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 1 )) ; 
            } 
        
        
        }
        
    private void GETMESSAGEBOX (  SplusExecutionContext __context__ ) 
        { 
        CrestronString SCOMMAND;
        SCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 824;
        MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "MSB") ) ; 
        __context__.SourceCodeLine = 825;
        ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
        
        }
        
    private void GETCURRENTSTATUSALL (  SplusExecutionContext __context__ ) 
        { 
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 837;
        GETPOWER (  __context__  ) ; 
        __context__.SourceCodeLine = 838;
        GETVIDEOINPUT (  __context__  ) ; 
        __context__.SourceCodeLine = 839;
        GETAUDIOINPUT (  __context__  ) ; 
        __context__.SourceCodeLine = 840;
        GETVOLUME (  __context__  ) ; 
        __context__.SourceCodeLine = 841;
        GETVOLUMEMUTE (  __context__  ) ; 
        __context__.SourceCodeLine = 842;
        GETBACKLIGHT (  __context__  ) ; 
        __context__.SourceCodeLine = 843;
        GETMESSAGEBOX (  __context__  ) ; 
        __context__.SourceCodeLine = 844;
        GETMULTISOURCEVIEW (  __context__  ) ; 
        __context__.SourceCodeLine = 845;
        GETPOWERSAVECONFIG (  __context__  ) ; 
        __context__.SourceCodeLine = 847;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)3; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            {
            __context__.SourceCodeLine = 848;
            GETMULTISOURCESELECT (  __context__ , (ushort)( I )) ; 
            __context__.SourceCodeLine = 847;
            }
        
        
        }
        
    private void SENDPOLL (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 853;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 855;
            Trace( "sendPoll()") ; 
            __context__.SourceCodeLine = 857;
            GETCURRENTSTATUSALL (  __context__  ) ; 
            __context__.SourceCodeLine = 859;
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
            __context__.SourceCodeLine = 860;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 1))  ) ) 
                {
                __context__.SourceCodeLine = 861;
                SENDPOLL (  __context__  ) ; 
                }
            
            }
        
        
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        
    }
    
private void STARTPOLL (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 867;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 869;
        UMODULE . NISPOLLING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 870;
        IS_POLLING  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 871;
        SENDPOLL (  __context__  ) ; 
        } 
    
    
    }
    
private void STOPPOLL (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 877;
    UMODULE . NISPOLLING = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 878;
    IS_POLLING  .Value = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 879;
    CancelWait ( "POLL" ) ; 
    
    }
    
private ushort ISINITIALIZED (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 888;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPOWER == 65535) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NVIDEOINPUT == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NAUDIOINPUT == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NVOLUMELEVEL == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NVOLUMEMUTE == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NMSVIEW == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NMSSELECT2 == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NMSSELECT3 == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NMSSELECT4 == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NPSCONFIG == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NBACKLIGHTLEVEL == 65535) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (UDEVICE.NMESSAGEBOX == 65535) )) ))  ) ) 
        {
        __context__.SourceCodeLine = 891;
        return (ushort)( 0) ; 
        }
    
    __context__.SourceCodeLine = 893;
    return (ushort)( 1) ; 
    
    }
    
private void GETINITIALIZED (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 898;
    Trace( "getInitialized()") ; 
    __context__.SourceCodeLine = 900;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISINITIALIZING == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (ISINITIALIZED( __context__ ) == 0) )) ))  ) ) 
        { 
        __context__.SourceCodeLine = 902;
        Trace( "passed test") ; 
        __context__.SourceCodeLine = 904;
        UMODULE . NISINITIALIZING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 905;
        GETCURRENTSTATUSALL (  __context__  ) ; 
        } 
    
    
    }
    
private void GOODRESPONSE (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 915;
    Trace( "goodResponse()") ; 
    __context__.SourceCodeLine = 917;
    UMODULE . NISCOMMUNICATING = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 918;
    IS_COMMUNICATING  .Value = (ushort) ( 1 ) ; 
    __context__.SourceCodeLine = 920;
    UQUEUE . NSTRIKECOUNT = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 922;
    Trace( "uModule.nLastOutWasHeartbeat[{0:d}]", (ushort)UMODULE.NLASTOUTWASHEARTBEAT) ; 
    __context__.SourceCodeLine = 923;
    Trace( "uDevice.nPower[{0:d}]", (ushort)UDEVICE.NPOWER) ; 
    __context__.SourceCodeLine = 924;
    Trace( "uModule.nIsInitializing[{0:d}]", (ushort)UMODULE.NISINITIALIZING) ; 
    __context__.SourceCodeLine = 926;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NLASTOUTWASHEARTBEAT == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISINITIALIZING == 0) )) ))  ) ) 
        {
        __context__.SourceCodeLine = 927;
        GETINITIALIZED (  __context__  ) ; 
        }
    
    __context__.SourceCodeLine = 929;
    UQUEUE . NBUSY = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 931;
    SENDNEXTQUEUEITEM (  __context__  ) ; 
    
    }
    
private void PROCESSDEVICEMSG (  SplusExecutionContext __context__ ) 
    { 
    CrestronString SSTATUS;
    SSTATUS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
    
    ushort NSTATUS = 0;
    
    ushort I = 0;
    
    
    __context__.SourceCodeLine = 940;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( UMODULE.SLASTMSGIN ) > 0 ))  ) ) 
        { 
        __context__.SourceCodeLine = 942;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "\u0008" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
            { 
            __context__.SourceCodeLine = 944;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "POW" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 946;
                SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "POW", "\u0008")  ) ; 
                __context__.SourceCodeLine = 948;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0001"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 950;
                    UDEVICE . NPOWER = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 951;
                    POWER_IS_ON  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 953;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0000"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 955;
                        UDEVICE . NPOWER = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 956;
                        POWER_IS_ON  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 959;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "VOL" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 961;
                    NSTATUS = (ushort) ( Byte( UMODULE.SLASTMSGIN , (int)( 7 ) ) ) ; 
                    __context__.SourceCodeLine = 963;
                    UDEVICE . NVOLUMELEVEL = (ushort) ( NSTATUS ) ; 
                    __context__.SourceCodeLine = 964;
                    VOLUME_LEVEL  .Value = (ushort) ( NSTATUS ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 966;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "MUT" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 968;
                        SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "MUT", "\u0008")  ) ; 
                        __context__.SourceCodeLine = 970;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0001"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 972;
                            UDEVICE . NVOLUMEMUTE = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 973;
                            VOLUME_IS_MUTED  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 975;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0000"))  ) ) 
                                { 
                                __context__.SourceCodeLine = 977;
                                UDEVICE . NVOLUMEMUTE = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 978;
                                VOLUME_IS_MUTED  .Value = (ushort) ( 0 ) ; 
                                } 
                            
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 981;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "BRI" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 983;
                            NSTATUS = (ushort) ( Byte( UMODULE.SLASTMSGIN , (int)( 7 ) ) ) ; 
                            __context__.SourceCodeLine = 985;
                            UDEVICE . NBACKLIGHTLEVEL = (ushort) ( NSTATUS ) ; 
                            __context__.SourceCodeLine = 986;
                            BACKLIGHT_LEVEL  .Value = (ushort) ( NSTATUS ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 988;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "MIN" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                { 
                                __context__.SourceCodeLine = 990;
                                SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "MIN", "\u0008")  ) ; 
                                __context__.SourceCodeLine = 992;
                                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                                ushort __FN_FOREND_VAL__1 = (ushort)7; 
                                int __FN_FORSTEP_VAL__1 = (int)1; 
                                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                                    { 
                                    __context__.SourceCodeLine = 994;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SVIDEOINPUTCOMMANDS[ I ]))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 996;
                                        UDEVICE . NVIDEOINPUT = (ushort) ( I ) ; 
                                        __context__.SourceCodeLine = 997;
                                        VIDEO_INPUTS_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1000;
                                        VIDEO_INPUTS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                        }
                                    
                                    __context__.SourceCodeLine = 992;
                                    } 
                                
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 1003;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "CAS" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1005;
                                    SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "CAS", "\u0008")  ) ; 
                                    __context__.SourceCodeLine = 1007;
                                    ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
                                    ushort __FN_FOREND_VAL__2 = (ushort)7; 
                                    int __FN_FORSTEP_VAL__2 = (int)1; 
                                    for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                                        { 
                                        __context__.SourceCodeLine = 1009;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SAUDIOINPUTCOMMANDS[ I ]))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1011;
                                            UDEVICE . NAUDIOINPUT = (ushort) ( I ) ; 
                                            __context__.SourceCodeLine = 1012;
                                            AUDIO_INPUTS_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1015;
                                            AUDIO_INPUTS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 1007;
                                        } 
                                    
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 1019;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "PSC" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 1021;
                                        SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "PSC", "\u0008")  ) ; 
                                        __context__.SourceCodeLine = 1023;
                                        ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
                                        ushort __FN_FOREND_VAL__3 = (ushort)8; 
                                        int __FN_FORSTEP_VAL__3 = (int)1; 
                                        for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                                            { 
                                            __context__.SourceCodeLine = 1025;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SMSVIEWCOMMANDS[ I ]))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 1027;
                                                UDEVICE . NMSVIEW = (ushort) ( I ) ; 
                                                __context__.SourceCodeLine = 1028;
                                                MULTISOURCE_VIEWS_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1031;
                                                MULTISOURCE_VIEWS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                                }
                                            
                                            __context__.SourceCodeLine = 1023;
                                            } 
                                        
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 1034;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "PIN" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 1036;
                                            SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "PIN", "\u0008")  ) ; 
                                            __context__.SourceCodeLine = 1038;
                                            ushort __FN_FORSTART_VAL__4 = (ushort) ( 1 ) ;
                                            ushort __FN_FOREND_VAL__4 = (ushort)7; 
                                            int __FN_FORSTEP_VAL__4 = (int)1; 
                                            for ( I  = __FN_FORSTART_VAL__4; (__FN_FORSTEP_VAL__4 > 0)  ? ( (I  >= __FN_FORSTART_VAL__4) && (I  <= __FN_FOREND_VAL__4) ) : ( (I  <= __FN_FORSTART_VAL__4) && (I  >= __FN_FOREND_VAL__4) ) ; I  += (ushort)__FN_FORSTEP_VAL__4) 
                                                { 
                                                __context__.SourceCodeLine = 1040;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SVIDEOINPUTCOMMANDS[ I ]))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 1042;
                                                    UDEVICE . NMSSELECT2 = (ushort) ( I ) ; 
                                                    __context__.SourceCodeLine = 1043;
                                                    MULTISOURCE_SELECT_2_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1046;
                                                    MULTISOURCE_SELECT_2_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                                    }
                                                
                                                __context__.SourceCodeLine = 1038;
                                                } 
                                            
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 1049;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "PIO" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 1051;
                                                SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "PIO", "\u0008")  ) ; 
                                                __context__.SourceCodeLine = 1053;
                                                ushort __FN_FORSTART_VAL__5 = (ushort) ( 1 ) ;
                                                ushort __FN_FOREND_VAL__5 = (ushort)7; 
                                                int __FN_FORSTEP_VAL__5 = (int)1; 
                                                for ( I  = __FN_FORSTART_VAL__5; (__FN_FORSTEP_VAL__5 > 0)  ? ( (I  >= __FN_FORSTART_VAL__5) && (I  <= __FN_FOREND_VAL__5) ) : ( (I  <= __FN_FORSTART_VAL__5) && (I  >= __FN_FOREND_VAL__5) ) ; I  += (ushort)__FN_FORSTEP_VAL__5) 
                                                    { 
                                                    __context__.SourceCodeLine = 1055;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SVIDEOINPUTCOMMANDS[ I ]))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 1057;
                                                        UDEVICE . NMSSELECT3 = (ushort) ( I ) ; 
                                                        __context__.SourceCodeLine = 1058;
                                                        MULTISOURCE_SELECT_3_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1061;
                                                        MULTISOURCE_SELECT_3_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                                        }
                                                    
                                                    __context__.SourceCodeLine = 1053;
                                                    } 
                                                
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 1064;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "PIP" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 1066;
                                                    SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "PIP", "\u0008")  ) ; 
                                                    __context__.SourceCodeLine = 1068;
                                                    ushort __FN_FORSTART_VAL__6 = (ushort) ( 1 ) ;
                                                    ushort __FN_FOREND_VAL__6 = (ushort)7; 
                                                    int __FN_FORSTEP_VAL__6 = (int)1; 
                                                    for ( I  = __FN_FORSTART_VAL__6; (__FN_FORSTEP_VAL__6 > 0)  ? ( (I  >= __FN_FORSTART_VAL__6) && (I  <= __FN_FOREND_VAL__6) ) : ( (I  <= __FN_FORSTART_VAL__6) && (I  >= __FN_FOREND_VAL__6) ) ; I  += (ushort)__FN_FORSTEP_VAL__6) 
                                                        { 
                                                        __context__.SourceCodeLine = 1070;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SVIDEOINPUTCOMMANDS[ I ]))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 1072;
                                                            UDEVICE . NMSSELECT4 = (ushort) ( I ) ; 
                                                            __context__.SourceCodeLine = 1073;
                                                            MULTISOURCE_SELECT_4_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                                            } 
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 1076;
                                                            MULTISOURCE_SELECT_4_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                                            }
                                                        
                                                        __context__.SourceCodeLine = 1068;
                                                        } 
                                                    
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 1079;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "PRC" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 1081;
                                                        SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "PRC", "\u0008")  ) ; 
                                                        __context__.SourceCodeLine = 1083;
                                                        ushort __FN_FORSTART_VAL__7 = (ushort) ( 1 ) ;
                                                        ushort __FN_FOREND_VAL__7 = (ushort)4; 
                                                        int __FN_FORSTEP_VAL__7 = (int)1; 
                                                        for ( I  = __FN_FORSTART_VAL__7; (__FN_FORSTEP_VAL__7 > 0)  ? ( (I  >= __FN_FORSTART_VAL__7) && (I  <= __FN_FOREND_VAL__7) ) : ( (I  <= __FN_FORSTART_VAL__7) && (I  >= __FN_FOREND_VAL__7) ) ; I  += (ushort)__FN_FORSTEP_VAL__7) 
                                                            { 
                                                            __context__.SourceCodeLine = 1085;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SMSPRESETCOMMANDS[ I ]))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 1086;
                                                                Functions.Pulse ( 10, MULTISOURCE_PRESETS_FB [ I] ) ; 
                                                                }
                                                            
                                                            __context__.SourceCodeLine = 1083;
                                                            } 
                                                        
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 1089;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "WFS" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 1091;
                                                            SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "WFS", "\u0008")  ) ; 
                                                            __context__.SourceCodeLine = 1093;
                                                            ushort __FN_FORSTART_VAL__8 = (ushort) ( 1 ) ;
                                                            ushort __FN_FOREND_VAL__8 = (ushort)3; 
                                                            int __FN_FORSTEP_VAL__8 = (int)1; 
                                                            for ( I  = __FN_FORSTART_VAL__8; (__FN_FORSTEP_VAL__8 > 0)  ? ( (I  >= __FN_FORSTART_VAL__8) && (I  <= __FN_FOREND_VAL__8) ) : ( (I  <= __FN_FORSTART_VAL__8) && (I  >= __FN_FOREND_VAL__8) ) ; I  += (ushort)__FN_FORSTEP_VAL__8) 
                                                                { 
                                                                __context__.SourceCodeLine = 1095;
                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == SPSCONFIGCOMMANDS[ I ]))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 1097;
                                                                    UDEVICE . NPSCONFIG = (ushort) ( I ) ; 
                                                                    __context__.SourceCodeLine = 1098;
                                                                    POWER_SAVE_CONFIGS_FB [ I]  .Value = (ushort) ( 1 ) ; 
                                                                    } 
                                                                
                                                                else 
                                                                    {
                                                                    __context__.SourceCodeLine = 1101;
                                                                    POWER_SAVE_CONFIGS_FB [ I]  .Value = (ushort) ( 0 ) ; 
                                                                    }
                                                                
                                                                __context__.SourceCodeLine = 1093;
                                                                } 
                                                            
                                                            } 
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    }
                
                }
            
            __context__.SourceCodeLine = 1104;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "MSB" , UMODULE.SLASTMSGIN ) == 1))  ) ) 
                { 
                __context__.SourceCodeLine = 1106;
                SSTATUS  .UpdateValue ( GETBOUNDSTRING (  __context__ , UMODULE.SLASTMSGIN, "MSB", "\u0008")  ) ; 
                __context__.SourceCodeLine = 1108;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0001"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1110;
                    UDEVICE . NMESSAGEBOX = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 1111;
                    MESSAGE_BOX_IS_ON  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 1113;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SSTATUS == "\u0000"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1115;
                        UDEVICE . NMESSAGEBOX = (ushort) ( 0 ) ; 
                        __context__.SourceCodeLine = 1116;
                        MESSAGE_BOX_IS_ON  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    }
                
                } 
            
            __context__.SourceCodeLine = 1120;
            CancelWait ( "QUEUEFALSERESPONSE" ) ; 
            __context__.SourceCodeLine = 1121;
            GOODRESPONSE (  __context__  ) ; 
            __context__.SourceCodeLine = 1123;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISINITIALIZING == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (ISINITIALIZED( __context__ ) == 1) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1125;
                Trace( "initialization complete") ; 
                __context__.SourceCodeLine = 1127;
                UMODULE . NISINITIALIZING = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 1128;
                UMODULE . NISINITIALIZED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1129;
                IS_INITIALIZED  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 1131;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (POLL_ENABLE  .Value == 1) ) && Functions.TestForTrue ( Functions.BoolToInt (UMODULE.NISPOLLING == 0) )) ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1132;
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
            __context__.SourceCodeLine = 1133;
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
    
    
    __context__.SourceCodeLine = 1147;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISHEARTBEATING == 1))  ) ) 
        { 
        __context__.SourceCodeLine = 1149;
        if ( Functions.TestForTrue  ( ( ISQUEUEEMPTY( __context__ ))  ) ) 
            { 
            __context__.SourceCodeLine = 1151;
            Trace( "sendHeartbeat()") ; 
            __context__.SourceCodeLine = 1153;
            MakeString ( SCOMMAND , "{0}", BUILDGETMSG (  __context__ , "GVE") ) ; 
            __context__.SourceCodeLine = 1154;
            ENQUEUE (  __context__ , SCOMMAND, (ushort)( 0 )) ; 
            } 
        
        __context__.SourceCodeLine = 1157;
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
            __context__.SourceCodeLine = 1158;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISHEARTBEATING == 1))  ) ) 
                {
                __context__.SourceCodeLine = 1159;
                SENDHEARTBEAT (  __context__  ) ; 
                }
            
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void STARTHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1165;
    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISHEARTBEATING == 0))  ) ) 
        { 
        __context__.SourceCodeLine = 1167;
        UMODULE . NISHEARTBEATING = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1168;
        SENDHEARTBEAT (  __context__  ) ; 
        } 
    
    
    }
    
private void STOPHEARTBEAT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1174;
    UMODULE . NISHEARTBEATING = (ushort) ( 0 ) ; 
    __context__.SourceCodeLine = 1175;
    CancelWait ( "HEARTBEAT" ) ; 
    
    }
    
private void DOCONNECT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1184;
    Trace( "doConnect()") ; 
    __context__.SourceCodeLine = 1186;
    RESET (  __context__  ) ; 
    __context__.SourceCodeLine = 1187;
    CancelWait ( "QUEUEFALSERESPONSE" ) ; 
    __context__.SourceCodeLine = 1189;
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
            __context__.SourceCodeLine = 1190;
            STARTHEARTBEAT (  __context__  ) ; 
            }
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    
}

private void DODISCONNECT (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1195;
    Trace( "doDisconnect()") ; 
    __context__.SourceCodeLine = 1197;
    RESET (  __context__  ) ; 
    __context__.SourceCodeLine = 1198;
    CancelWait ( "STARTHEARTBEATPROCESS" ) ; 
    __context__.SourceCodeLine = 1199;
    CancelWait ( "STARTPOLLINGPROCESS" ) ; 
    __context__.SourceCodeLine = 1200;
    CancelWait ( "QUEUEFALSERESPONSE" ) ; 
    __context__.SourceCodeLine = 1201;
    STOPHEARTBEAT (  __context__  ) ; 
    __context__.SourceCodeLine = 1202;
    STOPPOLL (  __context__  ) ; 
    
    }
    
private void DOREINITIALIZE (  SplusExecutionContext __context__ ) 
    { 
    
    __context__.SourceCodeLine = 1207;
    Trace( "doReinitialize()") ; 
    __context__.SourceCodeLine = 1209;
    DODISCONNECT (  __context__  ) ; 
    __context__.SourceCodeLine = 1210;
    DOCONNECT (  __context__  ) ; 
    
    }
    
object CONNECT_OnPush_0 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1220;
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
        
        __context__.SourceCodeLine = 1225;
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
        
        __context__.SourceCodeLine = 1230;
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
        
        __context__.SourceCodeLine = 1235;
        SETPOWER (  __context__ , (ushort)( 1 )) ; 
        
        
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
        
        __context__.SourceCodeLine = 1240;
        SETPOWER (  __context__ , (ushort)( 0 )) ; 
        
        
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
        
        __context__.SourceCodeLine = 1245;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NPOWER == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1246;
            SETPOWER (  __context__ , (ushort)( 0 )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1247;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NPOWER == 0))  ) ) 
                {
                __context__.SourceCodeLine = 1248;
                SETPOWER (  __context__ , (ushort)( 1 )) ; 
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
        
        __context__.SourceCodeLine = 1253;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NVOLUMELEVEL < 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1255;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (100 - UDEVICE.NVOLUMELEVEL) > VOLUME_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1256;
                SETVOLUME (  __context__ , (ushort)( (UDEVICE.NVOLUMELEVEL + VOLUME_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1258;
                SETVOLUME (  __context__ , (ushort)( 100 )) ; 
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
        
        __context__.SourceCodeLine = 1264;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NVOLUMELEVEL > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1266;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (UDEVICE.NVOLUMELEVEL - 0) > VOLUME_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1267;
                SETVOLUME (  __context__ , (ushort)( (UDEVICE.NVOLUMELEVEL - VOLUME_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1269;
                SETVOLUME (  __context__ , (ushort)( 0 )) ; 
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
        
        __context__.SourceCodeLine = 1275;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VOLUME_SET  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( VOLUME_SET  .UshortValue <= 100 ) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1276;
            SETVOLUME (  __context__ , (ushort)( VOLUME_SET  .UshortValue )) ; 
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
        
        __context__.SourceCodeLine = 1281;
        SETVOLUMEMUTE (  __context__ , (ushort)( 1 )) ; 
        
        
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
        
        __context__.SourceCodeLine = 1286;
        SETVOLUMEMUTE (  __context__ , (ushort)( 0 )) ; 
        
        
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
        
        __context__.SourceCodeLine = 1291;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NVOLUMEMUTE == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1292;
            SETVOLUMEMUTE (  __context__ , (ushort)( 0 )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1293;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NVOLUMEMUTE == 0))  ) ) 
                {
                __context__.SourceCodeLine = 1294;
                SETVOLUMEMUTE (  __context__ , (ushort)( 1 )) ; 
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
        
        __context__.SourceCodeLine = 1299;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NBACKLIGHTLEVEL < 100 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1301;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (100 - UDEVICE.NBACKLIGHTLEVEL) > BACKLIGHT_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1302;
                SETBACKLIGHT (  __context__ , (ushort)( (UDEVICE.NBACKLIGHTLEVEL + BACKLIGHT_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1304;
                SETBACKLIGHT (  __context__ , (ushort)( 100 )) ; 
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
        
        __context__.SourceCodeLine = 1310;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( UDEVICE.NBACKLIGHTLEVEL > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1312;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (UDEVICE.NBACKLIGHTLEVEL - 0) > BACKLIGHT_STEP_SIZE  .Value ))  ) ) 
                {
                __context__.SourceCodeLine = 1313;
                SETBACKLIGHT (  __context__ , (ushort)( (UDEVICE.NBACKLIGHTLEVEL - BACKLIGHT_STEP_SIZE  .Value) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1315;
                SETBACKLIGHT (  __context__ , (ushort)( 0 )) ; 
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
        
        __context__.SourceCodeLine = 1321;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( BACKLIGHT_SET  .UshortValue >= 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( BACKLIGHT_SET  .UshortValue <= 100 ) )) ))  ) ) 
            {
            __context__.SourceCodeLine = 1322;
            SETBACKLIGHT (  __context__ , (ushort)( BACKLIGHT_SET  .UshortValue )) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VIDEO_INPUTS_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INPUT = 0;
        
        
        __context__.SourceCodeLine = 1328;
        INPUT = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1330;
        SETVIDEOINPUT (  __context__ , (ushort)( INPUT )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object VIDEO_INPUT_CYCLE_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1335;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NVIDEOINPUT != 65535))  ) ) 
            { 
            __context__.SourceCodeLine = 1337;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NVIDEOINPUT == 7))  ) ) 
                {
                __context__.SourceCodeLine = 1338;
                SETVIDEOINPUT (  __context__ , (ushort)( 1 )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1340;
                SETVIDEOINPUT (  __context__ , (ushort)( (UDEVICE.NVIDEOINPUT + 1) )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AUDIO_INPUTS_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INPUT = 0;
        
        
        __context__.SourceCodeLine = 1347;
        INPUT = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1349;
        SETAUDIOINPUT (  __context__ , (ushort)( INPUT )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MULTISOURCE_VIEWS_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort VIEW = 0;
        
        
        __context__.SourceCodeLine = 1355;
        VIEW = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1357;
        SETMULTISOURCEVIEW (  __context__ , (ushort)( VIEW )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MULTISOURCE_VIEWS_CYCLE_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1362;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NMSVIEW != 65535))  ) ) 
            { 
            __context__.SourceCodeLine = 1364;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NMSVIEW == 8))  ) ) 
                {
                __context__.SourceCodeLine = 1365;
                SETMULTISOURCEVIEW (  __context__ , (ushort)( 1 )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1367;
                SETMULTISOURCEVIEW (  __context__ , (ushort)( (UDEVICE.NMSVIEW + 1) )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MULTISOURCE_SELECT_2_OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INPUT = 0;
        
        
        __context__.SourceCodeLine = 1374;
        INPUT = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1376;
        SETMULTISOURCESELECT (  __context__ , (ushort)( 1 ), (ushort)( INPUT )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MULTISOURCE_SELECT_3_OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INPUT = 0;
        
        
        __context__.SourceCodeLine = 1382;
        INPUT = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1384;
        SETMULTISOURCESELECT (  __context__ , (ushort)( 2 ), (ushort)( INPUT )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MULTISOURCE_SELECT_4_OnPush_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INPUT = 0;
        
        
        __context__.SourceCodeLine = 1390;
        INPUT = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1392;
        SETMULTISOURCESELECT (  __context__ , (ushort)( 3 ), (ushort)( INPUT )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MULTISOURCE_PRESETS_OnPush_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort PRESET = 0;
        
        
        __context__.SourceCodeLine = 1398;
        PRESET = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1400;
        SETMULTISOURCEPRESET (  __context__ , (ushort)( PRESET )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POWER_SAVE_CONFIGS_OnPush_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort CONFIG = 0;
        
        
        __context__.SourceCodeLine = 1406;
        CONFIG = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1408;
        SETPOWERSAVECONFIG (  __context__ , (ushort)( CONFIG )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POWER_SAVE_CONFIGS_CYCLE_OnPush_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1413;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NPSCONFIG != 65535))  ) ) 
            { 
            __context__.SourceCodeLine = 1415;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NPSCONFIG == 3))  ) ) 
                {
                __context__.SourceCodeLine = 1416;
                SETPOWERSAVECONFIG (  __context__ , (ushort)( 1 )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 1418;
                SETPOWERSAVECONFIG (  __context__ , (ushort)( (UDEVICE.NPSCONFIG + 1) )) ; 
                }
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object REMOTE_COMMANDS_OnPush_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IRFUNCTION = 0;
        
        
        __context__.SourceCodeLine = 1425;
        IRFUNCTION = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1427;
        SENDIR (  __context__ , (ushort)( IRFUNCTION )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MESSAGE_BOX_ON_OnPush_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1432;
        SETMESSAGEBOX (  __context__ , (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MESSAGE_BOX_OFF_OnPush_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1437;
        SETMESSAGEBOX (  __context__ , (ushort)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MESSAGE_BOX_TOGGLE_OnPush_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1442;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NMESSAGEBOX == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1443;
            SETMESSAGEBOX (  __context__ , (ushort)( 0 )) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1444;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UDEVICE.NMESSAGEBOX == 0))  ) ) 
                {
                __context__.SourceCodeLine = 1445;
                SETMESSAGEBOX (  __context__ , (ushort)( 1 )) ; 
                }
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_ENABLE_OnPush_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1450;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 0))  ) ) 
            {
            __context__.SourceCodeLine = 1451;
            STARTPOLL (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_ENABLE_OnRelease_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1456;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (UMODULE.NISPOLLING == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1457;
            STOPPOLL (  __context__  ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROM_DEVICE_OnChange_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString MSGTOCMDEND;
        MSGTOCMDEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        CrestronString MSGREMAINDER;
        MSGREMAINDER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
        
        
        __context__.SourceCodeLine = 1466;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 1468;
            try 
                { 
                __context__.SourceCodeLine = 1470;
                MSGTOCMDEND  .UpdateValue ( Functions.Gather ( 6, FROM_DEVICE )  ) ; 
                __context__.SourceCodeLine = 1473;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CONTAINS( __context__ , "GVE" , MSGTOCMDEND ) == 1))  ) ) 
                    {
                    __context__.SourceCodeLine = 1474;
                    MSGREMAINDER  .UpdateValue ( Functions.Gather ( 7, FROM_DEVICE )  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1477;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (CONTAINS( __context__ , "SER" , MSGTOCMDEND ) == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (CONTAINS( __context__ , "MNA" , MSGTOCMDEND ) == 1) )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1478;
                        MSGREMAINDER  .UpdateValue ( Functions.Gather ( 14, FROM_DEVICE )  ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1482;
                        MSGREMAINDER  .UpdateValue ( Functions.Gather ( 2, FROM_DEVICE )  ) ; 
                        }
                    
                    }
                
                __context__.SourceCodeLine = 1484;
                MakeString ( UMODULE . SLASTMSGIN , "{0}{1}", MSGTOCMDEND , MSGREMAINDER ) ; 
                __context__.SourceCodeLine = 1485;
                PROCESSDEVICEMSG (  __context__  ) ; 
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 1489;
                Trace( "Issue with Device message handling\r\n") ; 
                
                }
                
                __context__.SourceCodeLine = 1466;
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
        
        __context__.SourceCodeLine = 1536;
        SVIDEOINPUTCOMMANDS [ 1 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1537;
        SVIDEOINPUTCOMMANDS [ 2 ]  .UpdateValue ( "\u000D"  ) ; 
        __context__.SourceCodeLine = 1538;
        SVIDEOINPUTCOMMANDS [ 3 ]  .UpdateValue ( "\u000E"  ) ; 
        __context__.SourceCodeLine = 1539;
        SVIDEOINPUTCOMMANDS [ 4 ]  .UpdateValue ( "\u0009"  ) ; 
        __context__.SourceCodeLine = 1540;
        SVIDEOINPUTCOMMANDS [ 5 ]  .UpdateValue ( "\u000A"  ) ; 
        __context__.SourceCodeLine = 1541;
        SVIDEOINPUTCOMMANDS [ 6 ]  .UpdateValue ( "\u000B"  ) ; 
        __context__.SourceCodeLine = 1542;
        SVIDEOINPUTCOMMANDS [ 7 ]  .UpdateValue ( "\u000C"  ) ; 
        __context__.SourceCodeLine = 1544;
        SAUDIOINPUTCOMMANDS [ 1 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1545;
        SAUDIOINPUTCOMMANDS [ 2 ]  .UpdateValue ( "\u0001"  ) ; 
        __context__.SourceCodeLine = 1546;
        SAUDIOINPUTCOMMANDS [ 3 ]  .UpdateValue ( "\u0002"  ) ; 
        __context__.SourceCodeLine = 1547;
        SAUDIOINPUTCOMMANDS [ 4 ]  .UpdateValue ( "\u0003"  ) ; 
        __context__.SourceCodeLine = 1548;
        SAUDIOINPUTCOMMANDS [ 5 ]  .UpdateValue ( "\u0004"  ) ; 
        __context__.SourceCodeLine = 1549;
        SAUDIOINPUTCOMMANDS [ 6 ]  .UpdateValue ( "\u0005"  ) ; 
        __context__.SourceCodeLine = 1550;
        SAUDIOINPUTCOMMANDS [ 7 ]  .UpdateValue ( "\u0007"  ) ; 
        __context__.SourceCodeLine = 1552;
        SMSVIEWCOMMANDS [ 1 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1553;
        SMSVIEWCOMMANDS [ 2 ]  .UpdateValue ( "\u0001"  ) ; 
        __context__.SourceCodeLine = 1554;
        SMSVIEWCOMMANDS [ 3 ]  .UpdateValue ( "\u0002"  ) ; 
        __context__.SourceCodeLine = 1555;
        SMSVIEWCOMMANDS [ 4 ]  .UpdateValue ( "\u0003"  ) ; 
        __context__.SourceCodeLine = 1556;
        SMSVIEWCOMMANDS [ 5 ]  .UpdateValue ( "\u0004"  ) ; 
        __context__.SourceCodeLine = 1557;
        SMSVIEWCOMMANDS [ 6 ]  .UpdateValue ( "\u0005"  ) ; 
        __context__.SourceCodeLine = 1558;
        SMSVIEWCOMMANDS [ 7 ]  .UpdateValue ( "\u0006"  ) ; 
        __context__.SourceCodeLine = 1559;
        SMSVIEWCOMMANDS [ 8 ]  .UpdateValue ( "\u0007"  ) ; 
        __context__.SourceCodeLine = 1561;
        SMSPRESETCOMMANDS [ 1 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1562;
        SMSPRESETCOMMANDS [ 2 ]  .UpdateValue ( "\u0001"  ) ; 
        __context__.SourceCodeLine = 1563;
        SMSPRESETCOMMANDS [ 3 ]  .UpdateValue ( "\u0002"  ) ; 
        __context__.SourceCodeLine = 1564;
        SMSPRESETCOMMANDS [ 4 ]  .UpdateValue ( "\u0003"  ) ; 
        __context__.SourceCodeLine = 1566;
        SPSCONFIGCOMMANDS [ 1 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1567;
        SPSCONFIGCOMMANDS [ 2 ]  .UpdateValue ( "\u0001"  ) ; 
        __context__.SourceCodeLine = 1568;
        SPSCONFIGCOMMANDS [ 3 ]  .UpdateValue ( "\u0002"  ) ; 
        __context__.SourceCodeLine = 1570;
        SREMOTECOMMANDS [ 1 ]  .UpdateValue ( "\u000E"  ) ; 
        __context__.SourceCodeLine = 1571;
        SREMOTECOMMANDS [ 2 ]  .UpdateValue ( "\u0004"  ) ; 
        __context__.SourceCodeLine = 1572;
        SREMOTECOMMANDS [ 3 ]  .UpdateValue ( "\u0002"  ) ; 
        __context__.SourceCodeLine = 1573;
        SREMOTECOMMANDS [ 4 ]  .UpdateValue ( "\u0019"  ) ; 
        __context__.SourceCodeLine = 1574;
        SREMOTECOMMANDS [ 5 ]  .UpdateValue ( "\u0001"  ) ; 
        __context__.SourceCodeLine = 1575;
        SREMOTECOMMANDS [ 6 ]  .UpdateValue ( "\u0003"  ) ; 
        __context__.SourceCodeLine = 1576;
        SREMOTECOMMANDS [ 7 ]  .UpdateValue ( "\u0012"  ) ; 
        __context__.SourceCodeLine = 1577;
        SREMOTECOMMANDS [ 8 ]  .UpdateValue ( "\u0005"  ) ; 
        __context__.SourceCodeLine = 1578;
        SREMOTECOMMANDS [ 9 ]  .UpdateValue ( "\u0007"  ) ; 
        __context__.SourceCodeLine = 1579;
        SREMOTECOMMANDS [ 10 ]  .UpdateValue ( "\u0009"  ) ; 
        __context__.SourceCodeLine = 1580;
        SREMOTECOMMANDS [ 11 ]  .UpdateValue ( "\u000C"  ) ; 
        __context__.SourceCodeLine = 1581;
        SREMOTECOMMANDS [ 12 ]  .UpdateValue ( "\u0010"  ) ; 
        __context__.SourceCodeLine = 1582;
        SREMOTECOMMANDS [ 13 ]  .UpdateValue ( "\u0016"  ) ; 
        __context__.SourceCodeLine = 1583;
        SREMOTECOMMANDS [ 14 ]  .UpdateValue ( "\u0008"  ) ; 
        __context__.SourceCodeLine = 1584;
        SREMOTECOMMANDS [ 15 ]  .UpdateValue ( "\u0015"  ) ; 
        __context__.SourceCodeLine = 1585;
        SREMOTECOMMANDS [ 16 ]  .UpdateValue ( "\u000F"  ) ; 
        __context__.SourceCodeLine = 1586;
        SREMOTECOMMANDS [ 17 ]  .UpdateValue ( "\u0013"  ) ; 
        __context__.SourceCodeLine = 1587;
        SREMOTECOMMANDS [ 18 ]  .UpdateValue ( "\u0011"  ) ; 
        __context__.SourceCodeLine = 1588;
        SREMOTECOMMANDS [ 19 ]  .UpdateValue ( "\u001A"  ) ; 
        __context__.SourceCodeLine = 1589;
        SREMOTECOMMANDS [ 20 ]  .UpdateValue ( "\u0006"  ) ; 
        __context__.SourceCodeLine = 1590;
        SREMOTECOMMANDS [ 21 ]  .UpdateValue ( "\u0014"  ) ; 
        __context__.SourceCodeLine = 1591;
        SREMOTECOMMANDS [ 22 ]  .UpdateValue ( "\u0043"  ) ; 
        __context__.SourceCodeLine = 1592;
        SREMOTECOMMANDS [ 23 ]  .UpdateValue ( "\u0000"  ) ; 
        __context__.SourceCodeLine = 1593;
        SREMOTECOMMANDS [ 24 ]  .UpdateValue ( "\u0017"  ) ; 
        __context__.SourceCodeLine = 1594;
        SREMOTECOMMANDS [ 25 ]  .UpdateValue ( "\u0018"  ) ; 
        __context__.SourceCodeLine = 1595;
        SREMOTECOMMANDS [ 26 ]  .UpdateValue ( "\u001E"  ) ; 
        __context__.SourceCodeLine = 1596;
        SREMOTECOMMANDS [ 27 ]  .UpdateValue ( "\u001D"  ) ; 
        __context__.SourceCodeLine = 1597;
        SREMOTECOMMANDS [ 28 ]  .UpdateValue ( "\u001B"  ) ; 
        __context__.SourceCodeLine = 1598;
        SREMOTECOMMANDS [ 29 ]  .UpdateValue ( "\u0020"  ) ; 
        __context__.SourceCodeLine = 1599;
        SREMOTECOMMANDS [ 30 ]  .UpdateValue ( "\u0021"  ) ; 
        __context__.SourceCodeLine = 1600;
        SREMOTECOMMANDS [ 31 ]  .UpdateValue ( "\u0022"  ) ; 
        __context__.SourceCodeLine = 1601;
        SREMOTECOMMANDS [ 32 ]  .UpdateValue ( "\u0023"  ) ; 
        __context__.SourceCodeLine = 1602;
        SREMOTECOMMANDS [ 33 ]  .UpdateValue ( "\u0024"  ) ; 
        __context__.SourceCodeLine = 1603;
        SREMOTECOMMANDS [ 34 ]  .UpdateValue ( "\u0025"  ) ; 
        __context__.SourceCodeLine = 1604;
        SREMOTECOMMANDS [ 35 ]  .UpdateValue ( "\u0026"  ) ; 
        __context__.SourceCodeLine = 1605;
        SREMOTECOMMANDS [ 36 ]  .UpdateValue ( "\u0027"  ) ; 
        __context__.SourceCodeLine = 1607;
        UMODULE . NISHEARTBEATING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1608;
        UMODULE . NISPOLLING = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1610;
        RESET (  __context__  ) ; 
        __context__.SourceCodeLine = 1612;
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
    SVIDEOINPUTCOMMANDS  = new CrestronString[ 8 ];
    for( uint i = 0; i < 8; i++ )
        SVIDEOINPUTCOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SAUDIOINPUTCOMMANDS  = new CrestronString[ 8 ];
    for( uint i = 0; i < 8; i++ )
        SAUDIOINPUTCOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SMSVIEWCOMMANDS  = new CrestronString[ 9 ];
    for( uint i = 0; i < 9; i++ )
        SMSVIEWCOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SMSPRESETCOMMANDS  = new CrestronString[ 5 ];
    for( uint i = 0; i < 5; i++ )
        SMSPRESETCOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SPSCONFIGCOMMANDS  = new CrestronString[ 4 ];
    for( uint i = 0; i < 4; i++ )
        SPSCONFIGCOMMANDS [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    SREMOTECOMMANDS  = new CrestronString[ 37 ];
    for( uint i = 0; i < 37; i++ )
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
    
    MESSAGE_BOX_ON = new Crestron.Logos.SplusObjects.DigitalInput( MESSAGE_BOX_ON__DigitalInput__, this );
    m_DigitalInputList.Add( MESSAGE_BOX_ON__DigitalInput__, MESSAGE_BOX_ON );
    
    MESSAGE_BOX_OFF = new Crestron.Logos.SplusObjects.DigitalInput( MESSAGE_BOX_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( MESSAGE_BOX_OFF__DigitalInput__, MESSAGE_BOX_OFF );
    
    MESSAGE_BOX_TOGGLE = new Crestron.Logos.SplusObjects.DigitalInput( MESSAGE_BOX_TOGGLE__DigitalInput__, this );
    m_DigitalInputList.Add( MESSAGE_BOX_TOGGLE__DigitalInput__, MESSAGE_BOX_TOGGLE );
    
    POLL_ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( POLL_ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( POLL_ENABLE__DigitalInput__, POLL_ENABLE );
    
    VIDEO_INPUT_CYCLE = new Crestron.Logos.SplusObjects.DigitalInput( VIDEO_INPUT_CYCLE__DigitalInput__, this );
    m_DigitalInputList.Add( VIDEO_INPUT_CYCLE__DigitalInput__, VIDEO_INPUT_CYCLE );
    
    MULTISOURCE_VIEWS_CYCLE = new Crestron.Logos.SplusObjects.DigitalInput( MULTISOURCE_VIEWS_CYCLE__DigitalInput__, this );
    m_DigitalInputList.Add( MULTISOURCE_VIEWS_CYCLE__DigitalInput__, MULTISOURCE_VIEWS_CYCLE );
    
    POWER_SAVE_CONFIGS_CYCLE = new Crestron.Logos.SplusObjects.DigitalInput( POWER_SAVE_CONFIGS_CYCLE__DigitalInput__, this );
    m_DigitalInputList.Add( POWER_SAVE_CONFIGS_CYCLE__DigitalInput__, POWER_SAVE_CONFIGS_CYCLE );
    
    VIDEO_INPUTS = new InOutArray<DigitalInput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        VIDEO_INPUTS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( VIDEO_INPUTS__DigitalInput__ + i, VIDEO_INPUTS__DigitalInput__, this );
        m_DigitalInputList.Add( VIDEO_INPUTS__DigitalInput__ + i, VIDEO_INPUTS[i+1] );
    }
    
    AUDIO_INPUTS = new InOutArray<DigitalInput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        AUDIO_INPUTS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( AUDIO_INPUTS__DigitalInput__ + i, AUDIO_INPUTS__DigitalInput__, this );
        m_DigitalInputList.Add( AUDIO_INPUTS__DigitalInput__ + i, AUDIO_INPUTS[i+1] );
    }
    
    MULTISOURCE_VIEWS = new InOutArray<DigitalInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        MULTISOURCE_VIEWS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MULTISOURCE_VIEWS__DigitalInput__ + i, MULTISOURCE_VIEWS__DigitalInput__, this );
        m_DigitalInputList.Add( MULTISOURCE_VIEWS__DigitalInput__ + i, MULTISOURCE_VIEWS[i+1] );
    }
    
    MULTISOURCE_SELECT_2 = new InOutArray<DigitalInput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        MULTISOURCE_SELECT_2[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MULTISOURCE_SELECT_2__DigitalInput__ + i, MULTISOURCE_SELECT_2__DigitalInput__, this );
        m_DigitalInputList.Add( MULTISOURCE_SELECT_2__DigitalInput__ + i, MULTISOURCE_SELECT_2[i+1] );
    }
    
    MULTISOURCE_SELECT_3 = new InOutArray<DigitalInput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        MULTISOURCE_SELECT_3[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MULTISOURCE_SELECT_3__DigitalInput__ + i, MULTISOURCE_SELECT_3__DigitalInput__, this );
        m_DigitalInputList.Add( MULTISOURCE_SELECT_3__DigitalInput__ + i, MULTISOURCE_SELECT_3[i+1] );
    }
    
    MULTISOURCE_SELECT_4 = new InOutArray<DigitalInput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        MULTISOURCE_SELECT_4[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MULTISOURCE_SELECT_4__DigitalInput__ + i, MULTISOURCE_SELECT_4__DigitalInput__, this );
        m_DigitalInputList.Add( MULTISOURCE_SELECT_4__DigitalInput__ + i, MULTISOURCE_SELECT_4[i+1] );
    }
    
    MULTISOURCE_PRESETS = new InOutArray<DigitalInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        MULTISOURCE_PRESETS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( MULTISOURCE_PRESETS__DigitalInput__ + i, MULTISOURCE_PRESETS__DigitalInput__, this );
        m_DigitalInputList.Add( MULTISOURCE_PRESETS__DigitalInput__ + i, MULTISOURCE_PRESETS[i+1] );
    }
    
    POWER_SAVE_CONFIGS = new InOutArray<DigitalInput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        POWER_SAVE_CONFIGS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( POWER_SAVE_CONFIGS__DigitalInput__ + i, POWER_SAVE_CONFIGS__DigitalInput__, this );
        m_DigitalInputList.Add( POWER_SAVE_CONFIGS__DigitalInput__ + i, POWER_SAVE_CONFIGS[i+1] );
    }
    
    REMOTE_COMMANDS = new InOutArray<DigitalInput>( 36, this );
    for( uint i = 0; i < 36; i++ )
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
    
    MESSAGE_BOX_IS_ON = new Crestron.Logos.SplusObjects.DigitalOutput( MESSAGE_BOX_IS_ON__DigitalOutput__, this );
    m_DigitalOutputList.Add( MESSAGE_BOX_IS_ON__DigitalOutput__, MESSAGE_BOX_IS_ON );
    
    IS_POLLING = new Crestron.Logos.SplusObjects.DigitalOutput( IS_POLLING__DigitalOutput__, this );
    m_DigitalOutputList.Add( IS_POLLING__DigitalOutput__, IS_POLLING );
    
    VIDEO_INPUTS_FB = new InOutArray<DigitalOutput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        VIDEO_INPUTS_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( VIDEO_INPUTS_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( VIDEO_INPUTS_FB__DigitalOutput__ + i, VIDEO_INPUTS_FB[i+1] );
    }
    
    AUDIO_INPUTS_FB = new InOutArray<DigitalOutput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        AUDIO_INPUTS_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( AUDIO_INPUTS_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( AUDIO_INPUTS_FB__DigitalOutput__ + i, AUDIO_INPUTS_FB[i+1] );
    }
    
    MULTISOURCE_VIEWS_FB = new InOutArray<DigitalOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        MULTISOURCE_VIEWS_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MULTISOURCE_VIEWS_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MULTISOURCE_VIEWS_FB__DigitalOutput__ + i, MULTISOURCE_VIEWS_FB[i+1] );
    }
    
    MULTISOURCE_SELECT_2_FB = new InOutArray<DigitalOutput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        MULTISOURCE_SELECT_2_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MULTISOURCE_SELECT_2_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MULTISOURCE_SELECT_2_FB__DigitalOutput__ + i, MULTISOURCE_SELECT_2_FB[i+1] );
    }
    
    MULTISOURCE_SELECT_3_FB = new InOutArray<DigitalOutput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        MULTISOURCE_SELECT_3_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MULTISOURCE_SELECT_3_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MULTISOURCE_SELECT_3_FB__DigitalOutput__ + i, MULTISOURCE_SELECT_3_FB[i+1] );
    }
    
    MULTISOURCE_SELECT_4_FB = new InOutArray<DigitalOutput>( 7, this );
    for( uint i = 0; i < 7; i++ )
    {
        MULTISOURCE_SELECT_4_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MULTISOURCE_SELECT_4_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MULTISOURCE_SELECT_4_FB__DigitalOutput__ + i, MULTISOURCE_SELECT_4_FB[i+1] );
    }
    
    MULTISOURCE_PRESETS_FB = new InOutArray<DigitalOutput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        MULTISOURCE_PRESETS_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( MULTISOURCE_PRESETS_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( MULTISOURCE_PRESETS_FB__DigitalOutput__ + i, MULTISOURCE_PRESETS_FB[i+1] );
    }
    
    POWER_SAVE_CONFIGS_FB = new InOutArray<DigitalOutput>( 3, this );
    for( uint i = 0; i < 3; i++ )
    {
        POWER_SAVE_CONFIGS_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( POWER_SAVE_CONFIGS_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( POWER_SAVE_CONFIGS_FB__DigitalOutput__ + i, POWER_SAVE_CONFIGS_FB[i+1] );
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
    for( uint i = 0; i < 7; i++ )
        VIDEO_INPUTS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( VIDEO_INPUTS_OnPush_15, false ) );
        
    VIDEO_INPUT_CYCLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( VIDEO_INPUT_CYCLE_OnPush_16, false ) );
    for( uint i = 0; i < 7; i++ )
        AUDIO_INPUTS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( AUDIO_INPUTS_OnPush_17, false ) );
        
    for( uint i = 0; i < 8; i++ )
        MULTISOURCE_VIEWS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MULTISOURCE_VIEWS_OnPush_18, false ) );
        
    MULTISOURCE_VIEWS_CYCLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( MULTISOURCE_VIEWS_CYCLE_OnPush_19, false ) );
    for( uint i = 0; i < 7; i++ )
        MULTISOURCE_SELECT_2[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MULTISOURCE_SELECT_2_OnPush_20, false ) );
        
    for( uint i = 0; i < 7; i++ )
        MULTISOURCE_SELECT_3[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MULTISOURCE_SELECT_3_OnPush_21, false ) );
        
    for( uint i = 0; i < 7; i++ )
        MULTISOURCE_SELECT_4[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MULTISOURCE_SELECT_4_OnPush_22, false ) );
        
    for( uint i = 0; i < 4; i++ )
        MULTISOURCE_PRESETS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( MULTISOURCE_PRESETS_OnPush_23, false ) );
        
    for( uint i = 0; i < 3; i++ )
        POWER_SAVE_CONFIGS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( POWER_SAVE_CONFIGS_OnPush_24, false ) );
        
    POWER_SAVE_CONFIGS_CYCLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( POWER_SAVE_CONFIGS_CYCLE_OnPush_25, false ) );
    for( uint i = 0; i < 36; i++ )
        REMOTE_COMMANDS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( REMOTE_COMMANDS_OnPush_26, false ) );
        
    MESSAGE_BOX_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( MESSAGE_BOX_ON_OnPush_27, false ) );
    MESSAGE_BOX_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( MESSAGE_BOX_OFF_OnPush_28, false ) );
    MESSAGE_BOX_TOGGLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( MESSAGE_BOX_TOGGLE_OnPush_29, false ) );
    POLL_ENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnPush_30, false ) );
    POLL_ENABLE.OnDigitalRelease.Add( new InputChangeHandlerWrapper( POLL_ENABLE_OnRelease_31, false ) );
    FROM_DEVICE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE_OnChange_32, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_PLANAR_EP_SERIES_4K_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


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
const uint MESSAGE_BOX_ON__DigitalInput__ = 13;
const uint MESSAGE_BOX_OFF__DigitalInput__ = 14;
const uint MESSAGE_BOX_TOGGLE__DigitalInput__ = 15;
const uint POLL_ENABLE__DigitalInput__ = 16;
const uint VIDEO_INPUT_CYCLE__DigitalInput__ = 17;
const uint MULTISOURCE_VIEWS_CYCLE__DigitalInput__ = 18;
const uint POWER_SAVE_CONFIGS_CYCLE__DigitalInput__ = 19;
const uint VIDEO_INPUTS__DigitalInput__ = 20;
const uint AUDIO_INPUTS__DigitalInput__ = 27;
const uint MULTISOURCE_VIEWS__DigitalInput__ = 34;
const uint MULTISOURCE_SELECT_2__DigitalInput__ = 42;
const uint MULTISOURCE_SELECT_3__DigitalInput__ = 49;
const uint MULTISOURCE_SELECT_4__DigitalInput__ = 56;
const uint MULTISOURCE_PRESETS__DigitalInput__ = 63;
const uint POWER_SAVE_CONFIGS__DigitalInput__ = 67;
const uint REMOTE_COMMANDS__DigitalInput__ = 70;
const uint VOLUME_SET__AnalogSerialInput__ = 0;
const uint BACKLIGHT_SET__AnalogSerialInput__ = 1;
const uint FROM_DEVICE__AnalogSerialInput__ = 2;
const uint IS_COMMUNICATING__DigitalOutput__ = 0;
const uint IS_INITIALIZED__DigitalOutput__ = 1;
const uint POWER_IS_ON__DigitalOutput__ = 2;
const uint VOLUME_IS_MUTED__DigitalOutput__ = 3;
const uint MESSAGE_BOX_IS_ON__DigitalOutput__ = 4;
const uint IS_POLLING__DigitalOutput__ = 5;
const uint VIDEO_INPUTS_FB__DigitalOutput__ = 6;
const uint AUDIO_INPUTS_FB__DigitalOutput__ = 13;
const uint MULTISOURCE_VIEWS_FB__DigitalOutput__ = 20;
const uint MULTISOURCE_SELECT_2_FB__DigitalOutput__ = 28;
const uint MULTISOURCE_SELECT_3_FB__DigitalOutput__ = 35;
const uint MULTISOURCE_SELECT_4_FB__DigitalOutput__ = 42;
const uint MULTISOURCE_PRESETS_FB__DigitalOutput__ = 49;
const uint POWER_SAVE_CONFIGS_FB__DigitalOutput__ = 53;
const uint VOLUME_LEVEL__AnalogSerialOutput__ = 0;
const uint BACKLIGHT_LEVEL__AnalogSerialOutput__ = 1;
const uint TO_DEVICE__AnalogSerialOutput__ = 2;
const uint VOLUME_STEP_SIZE__Parameter__ = 10;
const uint BACKLIGHT_STEP_SIZE__Parameter__ = 11;

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
    public ushort  NVIDEOINPUT = 0;
    
    [SplusStructAttribute(2, false, false)]
    public ushort  NAUDIOINPUT = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  NVOLUMELEVEL = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  NVOLUMEMUTE = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  NBACKLIGHTLEVEL = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  NMSVIEW = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  NMSSELECT2 = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  NMSSELECT3 = 0;
    
    [SplusStructAttribute(9, false, false)]
    public ushort  NMSSELECT4 = 0;
    
    [SplusStructAttribute(10, false, false)]
    public ushort  NPSCONFIG = 0;
    
    [SplusStructAttribute(11, false, false)]
    public ushort  NMESSAGEBOX = 0;
    
    
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
