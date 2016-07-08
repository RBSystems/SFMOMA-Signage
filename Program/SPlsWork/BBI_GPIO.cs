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

namespace UserModule_BBI_GPIO
{
    public class UserModuleClass_BBI_GPIO : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput CONNECTF_TCP;
        Crestron.Logos.SplusObjects.DigitalInput PING_UDP;
        Crestron.Logos.SplusObjects.DigitalInput REFRESH;
        Crestron.Logos.SplusObjects.DigitalInput RELAY_ON;
        Crestron.Logos.SplusObjects.DigitalInput RELAY_OFF;
        Crestron.Logos.SplusObjects.DigitalInput RELAY_TOGGLE;
        Crestron.Logos.SplusObjects.DigitalInput QEPOSCLEAR;
        Crestron.Logos.SplusObjects.DigitalInput QEINDEXCLEAR;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DOUT_ON;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DOUT_OFF;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> DOUT_TOGGLE;
        Crestron.Logos.SplusObjects.BufferInput RX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> DUTYCYCLE;
        Crestron.Logos.SplusObjects.DigitalOutput RELAY_ON_FB;
        Crestron.Logos.SplusObjects.DigitalOutput RELAY_OFF_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DIN;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> DOUT_FB;
        Crestron.Logos.SplusObjects.AnalogOutput ADC;
        Crestron.Logos.SplusObjects.AnalogOutput QEPOSITION_FB;
        Crestron.Logos.SplusObjects.AnalogOutput QEINDEX_FB;
        Crestron.Logos.SplusObjects.StringOutput ERROR__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TX__DOLLAR__;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> DUTYCYCLE_FB;
        UShortParameter USE_TCP;
        UShortParameter PWM_FREQ;
        UShortParameter ADC_POLL_PERIOD;
        UShortParameter ADC_REPORT_DELTA;
        UShortParameter ADC_MIN;
        UShortParameter ADC_MAX;
        UShortParameter QEP_POLL_PERIOD;
        UShortParameter QEP_REPORT_DELTA;
        UShortParameter QEI_POLL_PERIOD;
        UShortParameter QEI_REPORT_DELTA;
        UShortParameter IO1_MODE;
        UShortParameter IO2_MODE;
        UShortParameter IO3_MODE;
        UShortParameter IO4_MODE;
        ushort HASCURRENT = 0;
        ushort RELAY = 0;
        ushort HASPING = 0;
        ushort [] CURRENTDOUT;
        ushort [] CURRENTMODE;
        private void SENDCOMMAND (  SplusExecutionContext __context__, CrestronString CMD ) 
            { 
            
            __context__.SourceCodeLine = 304;
            if ( Functions.TestForTrue  ( ( USE_TCP  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 306;
                if ( Functions.TestForTrue  ( ( CONNECTF_TCP  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 307;
                    TX__DOLLAR__  .UpdateValue ( CMD  ) ; 
                    }
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 310;
                TX__DOLLAR__  .UpdateValue ( CMD  ) ; 
                }
            
            
            }
            
        private void GETCURRENT (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            CrestronString CMD__DOLLAR__;
            CMD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
            
            
            __context__.SourceCodeLine = 318;
            MakeString ( CMD__DOLLAR__ , "ASM,{0:d}\u000D\u000A", (short)ADC_MIN  .Value) ; 
            __context__.SourceCodeLine = 319;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            __context__.SourceCodeLine = 320;
            MakeString ( CMD__DOLLAR__ , "ASX,{0:d}\u000D\u000A", (short)ADC_MAX  .Value) ; 
            __context__.SourceCodeLine = 321;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            __context__.SourceCodeLine = 322;
            MakeString ( CMD__DOLLAR__ , "ADRT,{0:d}\u000D\u000A", (short)ADC_REPORT_DELTA  .Value) ; 
            __context__.SourceCodeLine = 323;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            __context__.SourceCodeLine = 324;
            MakeString ( CMD__DOLLAR__ , "ADRP,{0:d}\u000D\u000A", (short)(ADC_POLL_PERIOD  .Value * 10)) ; 
            __context__.SourceCodeLine = 325;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            __context__.SourceCodeLine = 326;
            MakeString ( CMD__DOLLAR__ , "QERT,{0:d}\u000D\u000A", (short)QEP_REPORT_DELTA  .Value) ; 
            __context__.SourceCodeLine = 327;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            __context__.SourceCodeLine = 328;
            MakeString ( CMD__DOLLAR__ , "QERP,{0:d}\u000D\u000A", (short)(QEP_POLL_PERIOD  .Value * 10)) ; 
            __context__.SourceCodeLine = 329;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            __context__.SourceCodeLine = 330;
            MakeString ( CMD__DOLLAR__ , "QERTI,{0:d}\u000D\u000A", (short)QEI_REPORT_DELTA  .Value) ; 
            __context__.SourceCodeLine = 331;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            __context__.SourceCodeLine = 332;
            MakeString ( CMD__DOLLAR__ , "QERPI,{0:d}\u000D\u000A", (short)(QEI_POLL_PERIOD  .Value * 10)) ; 
            __context__.SourceCodeLine = 333;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            __context__.SourceCodeLine = 334;
            MakeString ( CMD__DOLLAR__ , "PF,{0:d}\u000D\u000A", (short)PWM_FREQ  .Value) ; 
            __context__.SourceCodeLine = 335;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            __context__.SourceCodeLine = 336;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)4; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 338;
                MakeString ( CMD__DOLLAR__ , "IOM,{0:d},{1:d}\u000D\u000A", (short)I, (short)CURRENTMODE[ I ]) ; 
                __context__.SourceCodeLine = 339;
                SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
                __context__.SourceCodeLine = 336;
                } 
            
            __context__.SourceCodeLine = 341;
            SENDCOMMAND (  __context__ , "RL\u000D\u000A") ; 
            __context__.SourceCodeLine = 342;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)4; 
            int __FN_FORSTEP_VAL__2 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 344;
                MakeString ( CMD__DOLLAR__ , "DI,{0:d}\u000D\u000A", (short)I) ; 
                __context__.SourceCodeLine = 345;
                SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
                __context__.SourceCodeLine = 346;
                MakeString ( CMD__DOLLAR__ , "DO,{0:d}\u000D\u000A", (short)I) ; 
                __context__.SourceCodeLine = 347;
                SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
                __context__.SourceCodeLine = 342;
                } 
            
            __context__.SourceCodeLine = 349;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)4; 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                { 
                __context__.SourceCodeLine = 351;
                MakeString ( CMD__DOLLAR__ , "DC,{0:d}\u000D\u000A", (short)I) ; 
                __context__.SourceCodeLine = 352;
                SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
                __context__.SourceCodeLine = 349;
                } 
            
            __context__.SourceCodeLine = 354;
            HASCURRENT = (ushort) ( 1 ) ; 
            
            }
            
        private void PARSERESPONSE (  SplusExecutionContext __context__, CrestronString RESPONSE ) 
            { 
            ushort POS1 = 0;
            
            ushort VAL1 = 0;
            ushort VAL2 = 0;
            ushort DC = 0;
            ushort FRAC = 0;
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
            
            
            __context__.SourceCodeLine = 363;
            if ( Functions.TestForTrue  ( ( Functions.Find( "Error:" , RESPONSE ))  ) ) 
                { 
                __context__.SourceCodeLine = 365;
                ERROR__DOLLAR__  .UpdateValue ( RESPONSE  ) ; 
                __context__.SourceCodeLine = 366;
                return ; 
                } 
            
            __context__.SourceCodeLine = 368;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)1);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.Find( "*ADS," , RESPONSE )) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 372;
                        STEMP  .UpdateValue ( Functions.Remove ( "*ADS," , RESPONSE )  ) ; 
                        __context__.SourceCodeLine = 373;
                        ADC  .Value = (ushort) ( Functions.Atoi( RESPONSE ) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.Find( "*DC," , RESPONSE )) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 377;
                        STEMP  .UpdateValue ( Functions.Remove ( "*DC," , RESPONSE )  ) ; 
                        __context__.SourceCodeLine = 378;
                        VAL1 = (ushort) ( Functions.Atoi( RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 379;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VAL1 < 1 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( VAL1 > 4 ) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 380;
                            return ; 
                            }
                        
                        __context__.SourceCodeLine = 381;
                        POS1 = (ushort) ( Functions.Find( "," , RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 382;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (POS1 == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 383;
                            return ; 
                            }
                        
                        __context__.SourceCodeLine = 384;
                        STEMP  .UpdateValue ( Functions.Right ( RESPONSE ,  (int) ( (Functions.Length( RESPONSE ) - POS1) ) )  ) ; 
                        __context__.SourceCodeLine = 385;
                        DC = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                        __context__.SourceCodeLine = 386;
                        POS1 = (ushort) ( Functions.Find( "." , STEMP ) ) ; 
                        __context__.SourceCodeLine = 387;
                        STEMP  .UpdateValue ( Functions.Right ( STEMP ,  (int) ( (Functions.Length( STEMP ) - POS1) ) )  ) ; 
                        __context__.SourceCodeLine = 388;
                        FRAC = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                        __context__.SourceCodeLine = 389;
                        DUTYCYCLE_FB [ VAL1]  .Value = (ushort) ( ((DC * 656) + ((FRAC * 656) / 100)) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.Find( "*DI," , RESPONSE )) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 393;
                        STEMP  .UpdateValue ( Functions.Remove ( "*DI," , RESPONSE )  ) ; 
                        __context__.SourceCodeLine = 394;
                        VAL1 = (ushort) ( Functions.Atoi( RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 395;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VAL1 < 1 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( VAL1 > 4 ) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 396;
                            return ; 
                            }
                        
                        __context__.SourceCodeLine = 397;
                        POS1 = (ushort) ( Functions.Find( "," , RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 398;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (POS1 == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 399;
                            return ; 
                            }
                        
                        __context__.SourceCodeLine = 400;
                        STEMP  .UpdateValue ( Functions.Right ( RESPONSE ,  (int) ( (Functions.Length( RESPONSE ) - POS1) ) )  ) ; 
                        __context__.SourceCodeLine = 401;
                        VAL2 = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                        __context__.SourceCodeLine = 402;
                        DIN [ VAL1]  .Value = (ushort) ( Functions.BoolToInt (VAL2 != 0) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.Find( "*DO," , RESPONSE )) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 406;
                        STEMP  .UpdateValue ( Functions.Remove ( "*DO," , RESPONSE )  ) ; 
                        __context__.SourceCodeLine = 407;
                        VAL1 = (ushort) ( Functions.Atoi( RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 408;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VAL1 < 1 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( VAL1 > 4 ) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 409;
                            return ; 
                            }
                        
                        __context__.SourceCodeLine = 410;
                        POS1 = (ushort) ( Functions.Find( "," , RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 411;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (POS1 == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 412;
                            return ; 
                            }
                        
                        __context__.SourceCodeLine = 413;
                        STEMP  .UpdateValue ( Functions.Right ( RESPONSE ,  (int) ( (Functions.Length( RESPONSE ) - POS1) ) )  ) ; 
                        __context__.SourceCodeLine = 414;
                        VAL2 = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                        __context__.SourceCodeLine = 415;
                        CURRENTDOUT [ VAL1] = (ushort) ( Functions.BoolToInt (VAL2 != 0) ) ; 
                        __context__.SourceCodeLine = 416;
                        DOUT_FB [ VAL1]  .Value = (ushort) ( Functions.BoolToInt (VAL2 != 0) ) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.Find( "*IOM," , RESPONSE )) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 420;
                        STEMP  .UpdateValue ( Functions.Remove ( "*IOM," , RESPONSE )  ) ; 
                        __context__.SourceCodeLine = 421;
                        VAL1 = (ushort) ( Functions.Atoi( RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 422;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( VAL1 < 1 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( VAL1 > 4 ) )) ))  ) ) 
                            {
                            __context__.SourceCodeLine = 423;
                            return ; 
                            }
                        
                        __context__.SourceCodeLine = 424;
                        POS1 = (ushort) ( Functions.Find( "," , RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 425;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (POS1 == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 426;
                            return ; 
                            }
                        
                        __context__.SourceCodeLine = 427;
                        STEMP  .UpdateValue ( Functions.Right ( RESPONSE ,  (int) ( (Functions.Length( RESPONSE ) - POS1) ) )  ) ; 
                        __context__.SourceCodeLine = 428;
                        VAL2 = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                        __context__.SourceCodeLine = 429;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENTMODE[ VAL1 ] != VAL2))  ) ) 
                            { 
                            __context__.SourceCodeLine = 432;
                            MakeString ( STEMP , "IOM,{0:d},{1:d}\u000D\u000A", (short)VAL1, (short)CURRENTMODE[ VAL1 ]) ; 
                            __context__.SourceCodeLine = 433;
                            SENDCOMMAND (  __context__ , STEMP) ; 
                            } 
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.Find( "*QEI," , RESPONSE )) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 438;
                        STEMP  .UpdateValue ( Functions.Remove ( "*QEI," , RESPONSE )  ) ; 
                        __context__.SourceCodeLine = 439;
                        VAL1 = (ushort) ( Functions.Atoi( RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 440;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Left( RESPONSE , (int)( 1 ) ) == "-"))  ) ) 
                            {
                            __context__.SourceCodeLine = 441;
                            QEINDEX_FB  .Value = (ushort) ( Functions.ToInteger( -( VAL1 ) ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 443;
                            QEINDEX_FB  .Value = (ushort) ( VAL1 ) ; 
                            }
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.Find( "*QEP," , RESPONSE )) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 447;
                        STEMP  .UpdateValue ( Functions.Remove ( "*QEP," , RESPONSE )  ) ; 
                        __context__.SourceCodeLine = 448;
                        VAL1 = (ushort) ( Functions.Atoi( RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 449;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Left( RESPONSE , (int)( 1 ) ) == "-"))  ) ) 
                            {
                            __context__.SourceCodeLine = 450;
                            QEPOSITION_FB  .Value = (ushort) ( Functions.ToInteger( -( VAL1 ) ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 452;
                            QEPOSITION_FB  .Value = (ushort) ( VAL1 ) ; 
                            }
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( Functions.Find( "*RL," , RESPONSE )) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 456;
                        STEMP  .UpdateValue ( Functions.Remove ( "*RL," , RESPONSE )  ) ; 
                        __context__.SourceCodeLine = 457;
                        VAL1 = (ushort) ( Functions.Atoi( RESPONSE ) ) ; 
                        __context__.SourceCodeLine = 458;
                        RELAY = (ushort) ( Functions.BoolToInt (VAL1 != 0) ) ; 
                        __context__.SourceCodeLine = 459;
                        if ( Functions.TestForTrue  ( ( RELAY)  ) ) 
                            { 
                            __context__.SourceCodeLine = 461;
                            RELAY_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 462;
                            RELAY_ON_FB  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        else 
                            { 
                            __context__.SourceCodeLine = 466;
                            RELAY_ON_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 467;
                            RELAY_OFF_FB  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        object REFRESH_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 480;
                GETCURRENT (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object RELAY_ON_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 485;
            SENDCOMMAND (  __context__ , "RL,1\u000D\u000A") ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object RELAY_OFF_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 490;
        SENDCOMMAND (  __context__ , "RL,0\u000D\u000A") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RELAY_TOGGLE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 495;
        if ( Functions.TestForTrue  ( ( RELAY)  ) ) 
            {
            __context__.SourceCodeLine = 496;
            SENDCOMMAND (  __context__ , "RL,0\u000D\u000A") ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 498;
            SENDCOMMAND (  __context__ , "RL,1\u000D\u000A") ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DOUT_ON_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort WHICH = 0;
        
        CrestronString CMD__DOLLAR__;
        CMD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        
        __context__.SourceCodeLine = 506;
        WHICH = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 507;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENTMODE[ WHICH ] != 2))  ) ) 
            { 
            __context__.SourceCodeLine = 509;
            MakeString ( ERROR__DOLLAR__ , "IO {0:d} is not in output mode.", (short)WHICH) ; 
            __context__.SourceCodeLine = 510;
            Print( "IO {0:d} is not in output mode.\u000D\u000A", (short)WHICH) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 514;
            MakeString ( CMD__DOLLAR__ , "DO,{0:d},1\u000D\u000A", (short)WHICH) ; 
            __context__.SourceCodeLine = 515;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DOUT_OFF_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort WHICH = 0;
        
        CrestronString CMD__DOLLAR__;
        CMD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        
        __context__.SourceCodeLine = 524;
        WHICH = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 525;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENTMODE[ WHICH ] != 2))  ) ) 
            { 
            __context__.SourceCodeLine = 527;
            MakeString ( ERROR__DOLLAR__ , "IO {0:d} is not in output mode.", (short)WHICH) ; 
            __context__.SourceCodeLine = 528;
            Print( "IO {0:d} is not in output mode.\u000D\u000A", (short)WHICH) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 532;
            MakeString ( CMD__DOLLAR__ , "DO,{0:d},0\u000D\u000A", (short)WHICH) ; 
            __context__.SourceCodeLine = 533;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DOUT_TOGGLE_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort WHICH = 0;
        
        CrestronString CMD__DOLLAR__;
        CMD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        
        __context__.SourceCodeLine = 542;
        WHICH = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 543;
        MakeString ( CMD__DOLLAR__ , "DO,{0:d},{1:d}\u000D\u000A", (short)WHICH, (short)Functions.Not( CURRENTDOUT[ WHICH ] )) ; 
        __context__.SourceCodeLine = 544;
        SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object CONNECTF_TCP_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 549;
        CURRENTMODE [ 1] = (ushort) ( IO1_MODE  .Value ) ; 
        __context__.SourceCodeLine = 550;
        CURRENTMODE [ 2] = (ushort) ( IO2_MODE  .Value ) ; 
        __context__.SourceCodeLine = 551;
        CURRENTMODE [ 3] = (ushort) ( IO3_MODE  .Value ) ; 
        __context__.SourceCodeLine = 552;
        CURRENTMODE [ 4] = (ushort) ( IO4_MODE  .Value ) ; 
        __context__.SourceCodeLine = 553;
        GETCURRENT (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PING_UDP_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 558;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (HASCURRENT == 0))  ) ) 
            {
            __context__.SourceCodeLine = 559;
            GETCURRENT (  __context__  ) ; 
            }
        
        __context__.SourceCodeLine = 560;
        SENDCOMMAND (  __context__ , "PN\u000D\0x0A") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object QEPOSCLEAR_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 565;
        SENDCOMMAND (  __context__ , "QECP\u000D\u000A") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object QEINDEXCLEAR_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 570;
        SENDCOMMAND (  __context__ , "QECI\u000D\u000A") ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DUTYCYCLE_OnChange_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort WHICH = 0;
        
        ushort DC = 0;
        ushort FRAC = 0;
        
        CrestronString CMD__DOLLAR__;
        CMD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 32, this );
        
        
        __context__.SourceCodeLine = 579;
        WHICH = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 580;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (CURRENTMODE[ WHICH ] != 3))  ) ) 
            {
            __context__.SourceCodeLine = 581;
            MakeString ( ERROR__DOLLAR__ , "IO {0:d} is not in PWM mode.", (short)WHICH) ; 
            }
        
        else 
            { 
            __context__.SourceCodeLine = 584;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DUTYCYCLE[ WHICH ] .UshortValue == 65535))  ) ) 
                { 
                __context__.SourceCodeLine = 586;
                MakeString ( CMD__DOLLAR__ , "DC,{0:d},100\u000D\u000A", (short)WHICH) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 590;
                DC = (ushort) ( DUTYCYCLE[ WHICH ] .UshortValue ) ; 
                __context__.SourceCodeLine = 591;
                DC = (ushort) ( (((DC >> 2) + (DC >> 3)) + (DC >> 6)) ) ; 
                __context__.SourceCodeLine = 592;
                FRAC = (ushort) ( (DC & 255) ) ; 
                __context__.SourceCodeLine = 593;
                DC = (ushort) ( (DC >> 8) ) ; 
                __context__.SourceCodeLine = 594;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DC > 100 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 596;
                    DC = (ushort) ( 100 ) ; 
                    __context__.SourceCodeLine = 597;
                    FRAC = (ushort) ( 0 ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 601;
                    FRAC = (ushort) ( (FRAC * 100) ) ; 
                    __context__.SourceCodeLine = 602;
                    FRAC = (ushort) ( (((FRAC >> 7) + 1) / 2) ) ; 
                    } 
                
                __context__.SourceCodeLine = 604;
                MakeString ( CMD__DOLLAR__ , "DC,{0:d},{1:d}.{2:d2}\u000D\u000A", (short)WHICH, (short)DC, (short)FRAC) ; 
                } 
            
            __context__.SourceCodeLine = 606;
            SENDCOMMAND (  __context__ , CMD__DOLLAR__) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RX__DOLLAR___OnChange_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 256, this );
        
        
        __context__.SourceCodeLine = 615;
        try 
            { 
            __context__.SourceCodeLine = 617;
            while ( Functions.TestForTrue  ( ( 1)  ) ) 
                { 
                __context__.SourceCodeLine = 619;
                STEMP  .UpdateValue ( Functions.Gather ( "\u000D\u000A" , RX__DOLLAR__ )  ) ; 
                __context__.SourceCodeLine = 620;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( STEMP ) > 0 ))  ) ) 
                    {
                    __context__.SourceCodeLine = 621;
                    PARSERESPONSE (  __context__ , STEMP) ; 
                    }
                
                __context__.SourceCodeLine = 617;
                } 
            
            } 
        
        catch (Exception __splus_exception__)
            { 
            SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
            
            
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
        
        __context__.SourceCodeLine = 636;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 637;
        HASCURRENT = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    CURRENTDOUT  = new ushort[ 5 ];
    CURRENTMODE  = new ushort[ 5 ];
    
    CONNECTF_TCP = new Crestron.Logos.SplusObjects.DigitalInput( CONNECTF_TCP__DigitalInput__, this );
    m_DigitalInputList.Add( CONNECTF_TCP__DigitalInput__, CONNECTF_TCP );
    
    PING_UDP = new Crestron.Logos.SplusObjects.DigitalInput( PING_UDP__DigitalInput__, this );
    m_DigitalInputList.Add( PING_UDP__DigitalInput__, PING_UDP );
    
    REFRESH = new Crestron.Logos.SplusObjects.DigitalInput( REFRESH__DigitalInput__, this );
    m_DigitalInputList.Add( REFRESH__DigitalInput__, REFRESH );
    
    RELAY_ON = new Crestron.Logos.SplusObjects.DigitalInput( RELAY_ON__DigitalInput__, this );
    m_DigitalInputList.Add( RELAY_ON__DigitalInput__, RELAY_ON );
    
    RELAY_OFF = new Crestron.Logos.SplusObjects.DigitalInput( RELAY_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( RELAY_OFF__DigitalInput__, RELAY_OFF );
    
    RELAY_TOGGLE = new Crestron.Logos.SplusObjects.DigitalInput( RELAY_TOGGLE__DigitalInput__, this );
    m_DigitalInputList.Add( RELAY_TOGGLE__DigitalInput__, RELAY_TOGGLE );
    
    QEPOSCLEAR = new Crestron.Logos.SplusObjects.DigitalInput( QEPOSCLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( QEPOSCLEAR__DigitalInput__, QEPOSCLEAR );
    
    QEINDEXCLEAR = new Crestron.Logos.SplusObjects.DigitalInput( QEINDEXCLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( QEINDEXCLEAR__DigitalInput__, QEINDEXCLEAR );
    
    DOUT_ON = new InOutArray<DigitalInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        DOUT_ON[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DOUT_ON__DigitalInput__ + i, DOUT_ON__DigitalInput__, this );
        m_DigitalInputList.Add( DOUT_ON__DigitalInput__ + i, DOUT_ON[i+1] );
    }
    
    DOUT_OFF = new InOutArray<DigitalInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        DOUT_OFF[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DOUT_OFF__DigitalInput__ + i, DOUT_OFF__DigitalInput__, this );
        m_DigitalInputList.Add( DOUT_OFF__DigitalInput__ + i, DOUT_OFF[i+1] );
    }
    
    DOUT_TOGGLE = new InOutArray<DigitalInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        DOUT_TOGGLE[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( DOUT_TOGGLE__DigitalInput__ + i, DOUT_TOGGLE__DigitalInput__, this );
        m_DigitalInputList.Add( DOUT_TOGGLE__DigitalInput__ + i, DOUT_TOGGLE[i+1] );
    }
    
    RELAY_ON_FB = new Crestron.Logos.SplusObjects.DigitalOutput( RELAY_ON_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( RELAY_ON_FB__DigitalOutput__, RELAY_ON_FB );
    
    RELAY_OFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( RELAY_OFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( RELAY_OFF_FB__DigitalOutput__, RELAY_OFF_FB );
    
    DIN = new InOutArray<DigitalOutput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        DIN[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DIN__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DIN__DigitalOutput__ + i, DIN[i+1] );
    }
    
    DOUT_FB = new InOutArray<DigitalOutput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        DOUT_FB[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( DOUT_FB__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( DOUT_FB__DigitalOutput__ + i, DOUT_FB[i+1] );
    }
    
    DUTYCYCLE = new InOutArray<AnalogInput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        DUTYCYCLE[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( DUTYCYCLE__AnalogSerialInput__ + i, DUTYCYCLE__AnalogSerialInput__, this );
        m_AnalogInputList.Add( DUTYCYCLE__AnalogSerialInput__ + i, DUTYCYCLE[i+1] );
    }
    
    ADC = new Crestron.Logos.SplusObjects.AnalogOutput( ADC__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ADC__AnalogSerialOutput__, ADC );
    
    QEPOSITION_FB = new Crestron.Logos.SplusObjects.AnalogOutput( QEPOSITION_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( QEPOSITION_FB__AnalogSerialOutput__, QEPOSITION_FB );
    
    QEINDEX_FB = new Crestron.Logos.SplusObjects.AnalogOutput( QEINDEX_FB__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( QEINDEX_FB__AnalogSerialOutput__, QEINDEX_FB );
    
    DUTYCYCLE_FB = new InOutArray<AnalogOutput>( 4, this );
    for( uint i = 0; i < 4; i++ )
    {
        DUTYCYCLE_FB[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( DUTYCYCLE_FB__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( DUTYCYCLE_FB__AnalogSerialOutput__ + i, DUTYCYCLE_FB[i+1] );
    }
    
    ERROR__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( ERROR__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( ERROR__DOLLAR____AnalogSerialOutput__, ERROR__DOLLAR__ );
    
    TX__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TX__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TX__DOLLAR____AnalogSerialOutput__, TX__DOLLAR__ );
    
    RX__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( RX__DOLLAR____AnalogSerialInput__, 10000, this );
    m_StringInputList.Add( RX__DOLLAR____AnalogSerialInput__, RX__DOLLAR__ );
    
    USE_TCP = new UShortParameter( USE_TCP__Parameter__, this );
    m_ParameterList.Add( USE_TCP__Parameter__, USE_TCP );
    
    PWM_FREQ = new UShortParameter( PWM_FREQ__Parameter__, this );
    m_ParameterList.Add( PWM_FREQ__Parameter__, PWM_FREQ );
    
    ADC_POLL_PERIOD = new UShortParameter( ADC_POLL_PERIOD__Parameter__, this );
    m_ParameterList.Add( ADC_POLL_PERIOD__Parameter__, ADC_POLL_PERIOD );
    
    ADC_REPORT_DELTA = new UShortParameter( ADC_REPORT_DELTA__Parameter__, this );
    m_ParameterList.Add( ADC_REPORT_DELTA__Parameter__, ADC_REPORT_DELTA );
    
    ADC_MIN = new UShortParameter( ADC_MIN__Parameter__, this );
    m_ParameterList.Add( ADC_MIN__Parameter__, ADC_MIN );
    
    ADC_MAX = new UShortParameter( ADC_MAX__Parameter__, this );
    m_ParameterList.Add( ADC_MAX__Parameter__, ADC_MAX );
    
    QEP_POLL_PERIOD = new UShortParameter( QEP_POLL_PERIOD__Parameter__, this );
    m_ParameterList.Add( QEP_POLL_PERIOD__Parameter__, QEP_POLL_PERIOD );
    
    QEP_REPORT_DELTA = new UShortParameter( QEP_REPORT_DELTA__Parameter__, this );
    m_ParameterList.Add( QEP_REPORT_DELTA__Parameter__, QEP_REPORT_DELTA );
    
    QEI_POLL_PERIOD = new UShortParameter( QEI_POLL_PERIOD__Parameter__, this );
    m_ParameterList.Add( QEI_POLL_PERIOD__Parameter__, QEI_POLL_PERIOD );
    
    QEI_REPORT_DELTA = new UShortParameter( QEI_REPORT_DELTA__Parameter__, this );
    m_ParameterList.Add( QEI_REPORT_DELTA__Parameter__, QEI_REPORT_DELTA );
    
    IO1_MODE = new UShortParameter( IO1_MODE__Parameter__, this );
    m_ParameterList.Add( IO1_MODE__Parameter__, IO1_MODE );
    
    IO2_MODE = new UShortParameter( IO2_MODE__Parameter__, this );
    m_ParameterList.Add( IO2_MODE__Parameter__, IO2_MODE );
    
    IO3_MODE = new UShortParameter( IO3_MODE__Parameter__, this );
    m_ParameterList.Add( IO3_MODE__Parameter__, IO3_MODE );
    
    IO4_MODE = new UShortParameter( IO4_MODE__Parameter__, this );
    m_ParameterList.Add( IO4_MODE__Parameter__, IO4_MODE );
    
    
    REFRESH.OnDigitalPush.Add( new InputChangeHandlerWrapper( REFRESH_OnPush_0, false ) );
    RELAY_ON.OnDigitalPush.Add( new InputChangeHandlerWrapper( RELAY_ON_OnPush_1, false ) );
    RELAY_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( RELAY_OFF_OnPush_2, false ) );
    RELAY_TOGGLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( RELAY_TOGGLE_OnPush_3, false ) );
    for( uint i = 0; i < 4; i++ )
        DOUT_ON[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DOUT_ON_OnPush_4, false ) );
        
    for( uint i = 0; i < 4; i++ )
        DOUT_OFF[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DOUT_OFF_OnPush_5, false ) );
        
    for( uint i = 0; i < 4; i++ )
        DOUT_TOGGLE[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( DOUT_TOGGLE_OnPush_6, false ) );
        
    CONNECTF_TCP.OnDigitalPush.Add( new InputChangeHandlerWrapper( CONNECTF_TCP_OnPush_7, false ) );
    PING_UDP.OnDigitalPush.Add( new InputChangeHandlerWrapper( PING_UDP_OnPush_8, false ) );
    QEPOSCLEAR.OnDigitalPush.Add( new InputChangeHandlerWrapper( QEPOSCLEAR_OnPush_9, false ) );
    QEINDEXCLEAR.OnDigitalPush.Add( new InputChangeHandlerWrapper( QEINDEXCLEAR_OnPush_10, false ) );
    for( uint i = 0; i < 4; i++ )
        DUTYCYCLE[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( DUTYCYCLE_OnChange_11, false ) );
        
    RX__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( RX__DOLLAR___OnChange_12, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_BBI_GPIO ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint CONNECTF_TCP__DigitalInput__ = 0;
const uint PING_UDP__DigitalInput__ = 1;
const uint REFRESH__DigitalInput__ = 2;
const uint RELAY_ON__DigitalInput__ = 3;
const uint RELAY_OFF__DigitalInput__ = 4;
const uint RELAY_TOGGLE__DigitalInput__ = 5;
const uint QEPOSCLEAR__DigitalInput__ = 6;
const uint QEINDEXCLEAR__DigitalInput__ = 7;
const uint DOUT_ON__DigitalInput__ = 8;
const uint DOUT_OFF__DigitalInput__ = 12;
const uint DOUT_TOGGLE__DigitalInput__ = 16;
const uint RX__DOLLAR____AnalogSerialInput__ = 0;
const uint DUTYCYCLE__AnalogSerialInput__ = 1;
const uint RELAY_ON_FB__DigitalOutput__ = 0;
const uint RELAY_OFF_FB__DigitalOutput__ = 1;
const uint DIN__DigitalOutput__ = 2;
const uint DOUT_FB__DigitalOutput__ = 6;
const uint ADC__AnalogSerialOutput__ = 0;
const uint QEPOSITION_FB__AnalogSerialOutput__ = 1;
const uint QEINDEX_FB__AnalogSerialOutput__ = 2;
const uint ERROR__DOLLAR____AnalogSerialOutput__ = 3;
const uint TX__DOLLAR____AnalogSerialOutput__ = 4;
const uint DUTYCYCLE_FB__AnalogSerialOutput__ = 5;
const uint USE_TCP__Parameter__ = 10;
const uint PWM_FREQ__Parameter__ = 11;
const uint ADC_POLL_PERIOD__Parameter__ = 12;
const uint ADC_REPORT_DELTA__Parameter__ = 13;
const uint ADC_MIN__Parameter__ = 14;
const uint ADC_MAX__Parameter__ = 15;
const uint QEP_POLL_PERIOD__Parameter__ = 16;
const uint QEP_REPORT_DELTA__Parameter__ = 17;
const uint QEI_POLL_PERIOD__Parameter__ = 18;
const uint QEI_REPORT_DELTA__Parameter__ = 19;
const uint IO1_MODE__Parameter__ = 20;
const uint IO2_MODE__Parameter__ = 21;
const uint IO3_MODE__Parameter__ = 22;
const uint IO4_MODE__Parameter__ = 23;

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


}
