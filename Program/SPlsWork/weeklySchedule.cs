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

namespace UserModule_WEEKLYSCHEDULE
{
    public class UserModuleClass_WEEKLYSCHEDULE : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalInput SYSTEMISON;
        Crestron.Logos.SplusObjects.DigitalInput ENABLETOGGLE;
        Crestron.Logos.SplusObjects.DigitalInput MINUTETICK;
        Crestron.Logos.SplusObjects.DigitalInput HOURUP;
        Crestron.Logos.SplusObjects.DigitalInput HOURDOWN;
        Crestron.Logos.SplusObjects.DigitalInput MINUP;
        Crestron.Logos.SplusObjects.DigitalInput MINDOWN;
        Crestron.Logos.SplusObjects.DigitalInput MONSTARTUP;
        Crestron.Logos.SplusObjects.DigitalInput TUESTARTUP;
        Crestron.Logos.SplusObjects.DigitalInput WEDSTARTUP;
        Crestron.Logos.SplusObjects.DigitalInput THUSTARTUP;
        Crestron.Logos.SplusObjects.DigitalInput FRISTARTUP;
        Crestron.Logos.SplusObjects.DigitalInput SATSTARTUP;
        Crestron.Logos.SplusObjects.DigitalInput SUNSTARTUP;
        Crestron.Logos.SplusObjects.DigitalInput MONSHUTDOWN;
        Crestron.Logos.SplusObjects.DigitalInput TUESHUTDOWN;
        Crestron.Logos.SplusObjects.DigitalInput WEDSHUTDOWN;
        Crestron.Logos.SplusObjects.DigitalInput THUSHUTDOWN;
        Crestron.Logos.SplusObjects.DigitalInput FRISHUTDOWN;
        Crestron.Logos.SplusObjects.DigitalInput SATSHUTDOWN;
        Crestron.Logos.SplusObjects.DigitalInput SUNSHUTDOWN;
        Crestron.Logos.SplusObjects.DigitalInput SHUTDOWNOVERRIDE;
        Crestron.Logos.SplusObjects.StringInput DATE__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput ENABLED;
        Crestron.Logos.SplusObjects.DigitalOutput AFTERHOUR;
        Crestron.Logos.SplusObjects.DigitalOutput FORCEDONAFTERHOUR;
        Crestron.Logos.SplusObjects.DigitalOutput TURNONPULSE;
        Crestron.Logos.SplusObjects.DigitalOutput TURNOFFPULSE;
        Crestron.Logos.SplusObjects.DigitalOutput SHUTDOWNWARNING;
        Crestron.Logos.SplusObjects.StringOutput DOW__DOLLAR__;
        Crestron.Logos.SplusObjects.AnalogOutput STARTUP_HOUR;
        Crestron.Logos.SplusObjects.AnalogOutput STARTUP_MIN;
        Crestron.Logos.SplusObjects.AnalogOutput SHUTDOWN_HOUR;
        Crestron.Logos.SplusObjects.AnalogOutput SHUTDOWN_MIN;
        Crestron.Logos.SplusObjects.StringOutput MONSTARTUP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TUESTARTUP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput WEDSTARTUP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput THUSTARTUP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput FRISTARTUP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SATSTARTUP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SUNSTARTUP__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput MONSHUTDOWN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput TUESHUTDOWN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput WEDSHUTDOWN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput THUSHUTDOWN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput FRISHUTDOWN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SATSHUTDOWN__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput SUNSHUTDOWN__DOLLAR__;
        ushort SELECTED = 0;
        
        private void UPDATETIME (  SplusExecutionContext __context__, ushort WHICH ) 
            { 
            
            __context__.SourceCodeLine = 146;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)WHICH);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 151;
                        MakeString ( SUNSTARTUP__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.STARTUPHOUR[ WHICH ], (ushort)_SplusNVRAM.STARTUPMIN[ WHICH ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 156;
                        MakeString ( MONSTARTUP__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.STARTUPHOUR[ WHICH ], (ushort)_SplusNVRAM.STARTUPMIN[ WHICH ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 161;
                        MakeString ( TUESTARTUP__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.STARTUPHOUR[ WHICH ], (ushort)_SplusNVRAM.STARTUPMIN[ WHICH ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 166;
                        MakeString ( WEDSTARTUP__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.STARTUPHOUR[ WHICH ], (ushort)_SplusNVRAM.STARTUPMIN[ WHICH ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 171;
                        MakeString ( THUSTARTUP__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.STARTUPHOUR[ WHICH ], (ushort)_SplusNVRAM.STARTUPMIN[ WHICH ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 176;
                        MakeString ( FRISTARTUP__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.STARTUPHOUR[ WHICH ], (ushort)_SplusNVRAM.STARTUPMIN[ WHICH ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 181;
                        MakeString ( SATSTARTUP__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.STARTUPHOUR[ WHICH ], (ushort)_SplusNVRAM.STARTUPMIN[ WHICH ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 186;
                        MakeString ( SUNSHUTDOWN__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.SHUTDOWNHOUR[ (WHICH - 8) ], (ushort)_SplusNVRAM.SHUTDOWNMIN[ (WHICH - 8) ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 191;
                        MakeString ( MONSHUTDOWN__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.SHUTDOWNHOUR[ (WHICH - 8) ], (ushort)_SplusNVRAM.SHUTDOWNMIN[ (WHICH - 8) ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 10) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 196;
                        MakeString ( TUESHUTDOWN__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.SHUTDOWNHOUR[ (WHICH - 8) ], (ushort)_SplusNVRAM.SHUTDOWNMIN[ (WHICH - 8) ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 11) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 201;
                        MakeString ( WEDSHUTDOWN__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.SHUTDOWNHOUR[ (WHICH - 8) ], (ushort)_SplusNVRAM.SHUTDOWNMIN[ (WHICH - 8) ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 12) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 206;
                        MakeString ( THUSHUTDOWN__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.SHUTDOWNHOUR[ (WHICH - 8) ], (ushort)_SplusNVRAM.SHUTDOWNMIN[ (WHICH - 8) ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 13) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 211;
                        MakeString ( FRISHUTDOWN__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.SHUTDOWNHOUR[ (WHICH - 8) ], (ushort)_SplusNVRAM.SHUTDOWNMIN[ (WHICH - 8) ]) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 14) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 216;
                        MakeString ( SATSHUTDOWN__DOLLAR__ , "{0:d2}:{1:d2}", (ushort)_SplusNVRAM.SHUTDOWNHOUR[ (WHICH - 8) ], (ushort)_SplusNVRAM.SHUTDOWNMIN[ (WHICH - 8) ]) ; 
                        } 
                    
                    } 
                    
                }
                
            
            
            }
            
        private void CHECKSCHEDULE (  SplusExecutionContext __context__ ) 
            { 
            ushort DOW = 0;
            
            ushort HOUR = 0;
            
            ushort MINUTES = 0;
            
            ushort STARTUPMINUTES = 0;
            ushort SHUTDOWNMINUTES = 0;
            
            
            __context__.SourceCodeLine = 228;
            DOW = (ushort) ( Functions.GetDayOfWeekNum() ) ; 
            __context__.SourceCodeLine = 229;
            MINUTES = (ushort) ( ((Functions.GetHourNum() * 60) + Functions.GetMinutesNum()) ) ; 
            __context__.SourceCodeLine = 230;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (MINUTES == 240))  ) ) 
                { 
                __context__.SourceCodeLine = 233;
                Functions.Pulse ( 100, TURNOFFPULSE ) ; 
                __context__.SourceCodeLine = 234;
                AFTERHOUR  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 235;
                FORCEDONAFTERHOUR  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 236;
                return ; 
                } 
            
            __context__.SourceCodeLine = 238;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ENABLED  .Value == 0))  ) ) 
                {
                __context__.SourceCodeLine = 239;
                return ; 
                }
            
            __context__.SourceCodeLine = 240;
            STARTUPMINUTES = (ushort) ( ((_SplusNVRAM.STARTUPHOUR[ DOW ] * 60) + _SplusNVRAM.STARTUPMIN[ DOW ]) ) ; 
            __context__.SourceCodeLine = 241;
            SHUTDOWNMINUTES = (ushort) ( ((_SplusNVRAM.SHUTDOWNHOUR[ DOW ] * 60) + _SplusNVRAM.SHUTDOWNMIN[ DOW ]) ) ; 
            __context__.SourceCodeLine = 242;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( STARTUPMINUTES >= SHUTDOWNMINUTES ))  ) ) 
                { 
                __context__.SourceCodeLine = 245;
                return ; 
                } 
            
            __context__.SourceCodeLine = 247;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( MINUTES >= SHUTDOWNMINUTES ))  ) ) 
                { 
                __context__.SourceCodeLine = 249;
                AFTERHOUR  .Value = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 250;
                if ( Functions.TestForTrue  ( ( FORCEDONAFTERHOUR  .Value)  ) ) 
                    {
                    __context__.SourceCodeLine = 251;
                    return ; 
                    }
                
                __context__.SourceCodeLine = 252;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYSTEMISON  .Value != 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 254;
                    Functions.Pulse ( 100, TURNOFFPULSE ) ; 
                    } 
                
                __context__.SourceCodeLine = 256;
                return ; 
                } 
            
            __context__.SourceCodeLine = 258;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FORCEDONAFTERHOUR  .Value == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 260;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (SHUTDOWNMINUTES - MINUTES) <= 5 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 262;
                    Functions.Pulse ( 100, SHUTDOWNWARNING ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 265;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( MINUTES >= STARTUPMINUTES ))  ) ) 
                { 
                __context__.SourceCodeLine = 267;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SYSTEMISON  .Value == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 269;
                    Functions.Pulse ( 100, TURNONPULSE ) ; 
                    } 
                
                __context__.SourceCodeLine = 272;
                AFTERHOUR  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 273;
                return ; 
                } 
            
            
            }
            
        object SYSTEMISON_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 284;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( ENABLED  .Value ) && Functions.TestForTrue ( AFTERHOUR  .Value )) ) ) && Functions.TestForTrue ( SYSTEMISON  .Value )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 287;
                    FORCEDONAFTERHOUR  .Value = (ushort) ( 1 ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SHUTDOWNOVERRIDE_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 293;
            FORCEDONAFTERHOUR  .Value = (ushort) ( 1 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object SYSTEMISON_OnRelease_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 298;
        FORCEDONAFTERHOUR  .Value = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLETOGGLE_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 303;
        _SplusNVRAM.SCHENABLED = (ushort) ( Functions.Not( _SplusNVRAM.SCHENABLED ) ) ; 
        __context__.SourceCodeLine = 304;
        ENABLED  .Value = (ushort) ( _SplusNVRAM.SCHENABLED ) ; 
        __context__.SourceCodeLine = 305;
        CHECKSCHEDULE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOURUP_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 310;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SELECTED < 8 ))  ) ) 
            { 
            __context__.SourceCodeLine = 312;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.STARTUPHOUR[ SELECTED ] < 23 ))  ) ) 
                { 
                __context__.SourceCodeLine = 314;
                _SplusNVRAM.STARTUPHOUR [ SELECTED] = (ushort) ( (_SplusNVRAM.STARTUPHOUR[ SELECTED ] + 1) ) ; 
                __context__.SourceCodeLine = 315;
                UPDATETIME (  __context__ , (ushort)( SELECTED )) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 320;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SHUTDOWNHOUR[ (SELECTED - 8) ] < 23 ))  ) ) 
                { 
                __context__.SourceCodeLine = 322;
                _SplusNVRAM.SHUTDOWNHOUR [ (SELECTED - 8)] = (ushort) ( (_SplusNVRAM.SHUTDOWNHOUR[ (SELECTED - 8) ] + 1) ) ; 
                __context__.SourceCodeLine = 323;
                UPDATETIME (  __context__ , (ushort)( SELECTED )) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 326;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SELECTED == Functions.GetDayOfWeekNum()))  ) ) 
            { 
            __context__.SourceCodeLine = 328;
            STARTUP_HOUR  .Value = (ushort) ( _SplusNVRAM.STARTUPHOUR[ SELECTED ] ) ; 
            __context__.SourceCodeLine = 329;
            STARTUP_MIN  .Value = (ushort) ( _SplusNVRAM.STARTUPMIN[ SELECTED ] ) ; 
            __context__.SourceCodeLine = 330;
            CHECKSCHEDULE (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 332;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((SELECTED - 8) == Functions.GetDayOfWeekNum()))  ) ) 
                { 
                __context__.SourceCodeLine = 334;
                SHUTDOWN_HOUR  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNHOUR[ (SELECTED - 8) ] ) ; 
                __context__.SourceCodeLine = 335;
                SHUTDOWN_MIN  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNMIN[ (SELECTED - 8) ] ) ; 
                __context__.SourceCodeLine = 336;
                CHECKSCHEDULE (  __context__  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOURDOWN_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 342;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SELECTED < 8 ))  ) ) 
            { 
            __context__.SourceCodeLine = 344;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.STARTUPHOUR[ SELECTED ] > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 346;
                _SplusNVRAM.STARTUPHOUR [ SELECTED] = (ushort) ( (_SplusNVRAM.STARTUPHOUR[ SELECTED ] - 1) ) ; 
                __context__.SourceCodeLine = 347;
                UPDATETIME (  __context__ , (ushort)( SELECTED )) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 352;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SHUTDOWNHOUR[ (SELECTED - 8) ] > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 354;
                _SplusNVRAM.SHUTDOWNHOUR [ (SELECTED - 8)] = (ushort) ( (_SplusNVRAM.SHUTDOWNHOUR[ (SELECTED - 8) ] - 1) ) ; 
                __context__.SourceCodeLine = 355;
                UPDATETIME (  __context__ , (ushort)( SELECTED )) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 358;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SELECTED == Functions.GetDayOfWeekNum()))  ) ) 
            { 
            __context__.SourceCodeLine = 360;
            STARTUP_HOUR  .Value = (ushort) ( _SplusNVRAM.STARTUPHOUR[ SELECTED ] ) ; 
            __context__.SourceCodeLine = 361;
            STARTUP_MIN  .Value = (ushort) ( _SplusNVRAM.STARTUPMIN[ SELECTED ] ) ; 
            __context__.SourceCodeLine = 362;
            CHECKSCHEDULE (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 364;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((SELECTED - 8) == Functions.GetDayOfWeekNum()))  ) ) 
                { 
                __context__.SourceCodeLine = 366;
                SHUTDOWN_HOUR  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNHOUR[ (SELECTED - 8) ] ) ; 
                __context__.SourceCodeLine = 367;
                SHUTDOWN_MIN  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNMIN[ (SELECTED - 8) ] ) ; 
                __context__.SourceCodeLine = 368;
                CHECKSCHEDULE (  __context__  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINUP_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 374;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SELECTED < 8 ))  ) ) 
            { 
            __context__.SourceCodeLine = 376;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.STARTUPMIN[ SELECTED ] < 55 ))  ) ) 
                { 
                __context__.SourceCodeLine = 378;
                _SplusNVRAM.STARTUPMIN [ SELECTED] = (ushort) ( (_SplusNVRAM.STARTUPMIN[ SELECTED ] + 5) ) ; 
                __context__.SourceCodeLine = 379;
                UPDATETIME (  __context__ , (ushort)( SELECTED )) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 384;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SHUTDOWNMIN[ (SELECTED - 8) ] < 55 ))  ) ) 
                { 
                __context__.SourceCodeLine = 386;
                _SplusNVRAM.SHUTDOWNMIN [ (SELECTED - 8)] = (ushort) ( (_SplusNVRAM.SHUTDOWNMIN[ (SELECTED - 8) ] + 5) ) ; 
                __context__.SourceCodeLine = 387;
                UPDATETIME (  __context__ , (ushort)( SELECTED )) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 390;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SELECTED == Functions.GetDayOfWeekNum()))  ) ) 
            { 
            __context__.SourceCodeLine = 392;
            STARTUP_HOUR  .Value = (ushort) ( _SplusNVRAM.STARTUPHOUR[ SELECTED ] ) ; 
            __context__.SourceCodeLine = 393;
            STARTUP_MIN  .Value = (ushort) ( _SplusNVRAM.STARTUPMIN[ SELECTED ] ) ; 
            __context__.SourceCodeLine = 394;
            CHECKSCHEDULE (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 396;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((SELECTED - 8) == Functions.GetDayOfWeekNum()))  ) ) 
                { 
                __context__.SourceCodeLine = 398;
                SHUTDOWN_HOUR  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNHOUR[ (SELECTED - 8) ] ) ; 
                __context__.SourceCodeLine = 399;
                SHUTDOWN_MIN  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNMIN[ (SELECTED - 8) ] ) ; 
                __context__.SourceCodeLine = 400;
                CHECKSCHEDULE (  __context__  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINDOWN_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 406;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( SELECTED < 8 ))  ) ) 
            { 
            __context__.SourceCodeLine = 408;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.STARTUPMIN[ SELECTED ] > 4 ))  ) ) 
                { 
                __context__.SourceCodeLine = 410;
                _SplusNVRAM.STARTUPMIN [ SELECTED] = (ushort) ( (_SplusNVRAM.STARTUPMIN[ SELECTED ] - 5) ) ; 
                __context__.SourceCodeLine = 411;
                UPDATETIME (  __context__ , (ushort)( SELECTED )) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 416;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( _SplusNVRAM.SHUTDOWNMIN[ (SELECTED - 8) ] > 4 ))  ) ) 
                { 
                __context__.SourceCodeLine = 418;
                _SplusNVRAM.SHUTDOWNMIN [ (SELECTED - 8)] = (ushort) ( (_SplusNVRAM.SHUTDOWNMIN[ (SELECTED - 8) ] - 5) ) ; 
                __context__.SourceCodeLine = 419;
                UPDATETIME (  __context__ , (ushort)( SELECTED )) ; 
                } 
            
            } 
        
        __context__.SourceCodeLine = 422;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SELECTED == Functions.GetDayOfWeekNum()))  ) ) 
            { 
            __context__.SourceCodeLine = 424;
            STARTUP_HOUR  .Value = (ushort) ( _SplusNVRAM.STARTUPHOUR[ SELECTED ] ) ; 
            __context__.SourceCodeLine = 425;
            STARTUP_MIN  .Value = (ushort) ( _SplusNVRAM.STARTUPMIN[ SELECTED ] ) ; 
            __context__.SourceCodeLine = 426;
            CHECKSCHEDULE (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 428;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((SELECTED - 8) == Functions.GetDayOfWeekNum()))  ) ) 
                { 
                __context__.SourceCodeLine = 430;
                SHUTDOWN_HOUR  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNHOUR[ (SELECTED - 8) ] ) ; 
                __context__.SourceCodeLine = 431;
                SHUTDOWN_MIN  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNMIN[ (SELECTED - 8) ] ) ; 
                __context__.SourceCodeLine = 432;
                CHECKSCHEDULE (  __context__  ) ; 
                } 
            
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINUTETICK_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 438;
        CHECKSCHEDULE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DATE__DOLLAR___OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort DOW = 0;
        
        
        __context__.SourceCodeLine = 445;
        DOW__DOLLAR__  .UpdateValue ( Functions.Day ( )  ) ; 
        __context__.SourceCodeLine = 446;
        DOW = (ushort) ( Functions.GetDayOfWeekNum() ) ; 
        __context__.SourceCodeLine = 447;
        STARTUP_HOUR  .Value = (ushort) ( _SplusNVRAM.STARTUPHOUR[ DOW ] ) ; 
        __context__.SourceCodeLine = 448;
        STARTUP_MIN  .Value = (ushort) ( _SplusNVRAM.STARTUPMIN[ DOW ] ) ; 
        __context__.SourceCodeLine = 449;
        SHUTDOWN_HOUR  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNHOUR[ DOW ] ) ; 
        __context__.SourceCodeLine = 450;
        SHUTDOWN_MIN  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNMIN[ DOW ] ) ; 
        __context__.SourceCodeLine = 451;
        CHECKSCHEDULE (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MONSTARTUP_OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 456;
        SELECTED = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TUESTARTUP_OnChange_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 461;
        SELECTED = (ushort) ( 2 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object WEDSTARTUP_OnChange_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 466;
        SELECTED = (ushort) ( 3 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object THUSTARTUP_OnChange_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 471;
        SELECTED = (ushort) ( 4 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FRISTARTUP_OnChange_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 476;
        SELECTED = (ushort) ( 5 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SATSTARTUP_OnChange_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 481;
        SELECTED = (ushort) ( 6 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUNSTARTUP_OnChange_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 486;
        SELECTED = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MONSHUTDOWN_OnChange_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 491;
        SELECTED = (ushort) ( 9 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TUESHUTDOWN_OnChange_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 496;
        SELECTED = (ushort) ( 10 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object WEDSHUTDOWN_OnChange_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 501;
        SELECTED = (ushort) ( 11 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object THUSHUTDOWN_OnChange_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 506;
        SELECTED = (ushort) ( 12 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FRISHUTDOWN_OnChange_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 511;
        SELECTED = (ushort) ( 13 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SATSHUTDOWN_OnChange_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 516;
        SELECTED = (ushort) ( 14 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUNSHUTDOWN_OnChange_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 521;
        SELECTED = (ushort) ( 8 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort I = 0;
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 536;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 542;
        SELECTED = (ushort) ( Functions.GetDayOfWeekNum() ) ; 
        __context__.SourceCodeLine = 543;
        DOW__DOLLAR__  .UpdateValue ( Functions.Day ( )  ) ; 
        __context__.SourceCodeLine = 544;
        ENABLED  .Value = (ushort) ( _SplusNVRAM.SCHENABLED ) ; 
        __context__.SourceCodeLine = 545;
        FORCEDONAFTERHOUR  .Value = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 546;
        STARTUP_HOUR  .Value = (ushort) ( _SplusNVRAM.STARTUPHOUR[ SELECTED ] ) ; 
        __context__.SourceCodeLine = 547;
        STARTUP_MIN  .Value = (ushort) ( _SplusNVRAM.STARTUPMIN[ SELECTED ] ) ; 
        __context__.SourceCodeLine = 548;
        SHUTDOWN_HOUR  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNHOUR[ SELECTED ] ) ; 
        __context__.SourceCodeLine = 549;
        SHUTDOWN_MIN  .Value = (ushort) ( _SplusNVRAM.SHUTDOWNMIN[ SELECTED ] ) ; 
        __context__.SourceCodeLine = 551;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)6; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 553;
            UPDATETIME (  __context__ , (ushort)( I )) ; 
            __context__.SourceCodeLine = 551;
            } 
        
        __context__.SourceCodeLine = 555;
        ushort __FN_FORSTART_VAL__2 = (ushort) ( 8 ) ;
        ushort __FN_FOREND_VAL__2 = (ushort)14; 
        int __FN_FORSTEP_VAL__2 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
            { 
            __context__.SourceCodeLine = 557;
            UPDATETIME (  __context__ , (ushort)( I )) ; 
            __context__.SourceCodeLine = 555;
            } 
        
        
        
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
    _SplusNVRAM.STARTUPHOUR  = new ushort[ 7 ];
    _SplusNVRAM.STARTUPMIN  = new ushort[ 7 ];
    _SplusNVRAM.SHUTDOWNHOUR  = new ushort[ 7 ];
    _SplusNVRAM.SHUTDOWNMIN  = new ushort[ 7 ];
    
    SYSTEMISON = new Crestron.Logos.SplusObjects.DigitalInput( SYSTEMISON__DigitalInput__, this );
    m_DigitalInputList.Add( SYSTEMISON__DigitalInput__, SYSTEMISON );
    
    ENABLETOGGLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLETOGGLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLETOGGLE__DigitalInput__, ENABLETOGGLE );
    
    MINUTETICK = new Crestron.Logos.SplusObjects.DigitalInput( MINUTETICK__DigitalInput__, this );
    m_DigitalInputList.Add( MINUTETICK__DigitalInput__, MINUTETICK );
    
    HOURUP = new Crestron.Logos.SplusObjects.DigitalInput( HOURUP__DigitalInput__, this );
    m_DigitalInputList.Add( HOURUP__DigitalInput__, HOURUP );
    
    HOURDOWN = new Crestron.Logos.SplusObjects.DigitalInput( HOURDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( HOURDOWN__DigitalInput__, HOURDOWN );
    
    MINUP = new Crestron.Logos.SplusObjects.DigitalInput( MINUP__DigitalInput__, this );
    m_DigitalInputList.Add( MINUP__DigitalInput__, MINUP );
    
    MINDOWN = new Crestron.Logos.SplusObjects.DigitalInput( MINDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( MINDOWN__DigitalInput__, MINDOWN );
    
    MONSTARTUP = new Crestron.Logos.SplusObjects.DigitalInput( MONSTARTUP__DigitalInput__, this );
    m_DigitalInputList.Add( MONSTARTUP__DigitalInput__, MONSTARTUP );
    
    TUESTARTUP = new Crestron.Logos.SplusObjects.DigitalInput( TUESTARTUP__DigitalInput__, this );
    m_DigitalInputList.Add( TUESTARTUP__DigitalInput__, TUESTARTUP );
    
    WEDSTARTUP = new Crestron.Logos.SplusObjects.DigitalInput( WEDSTARTUP__DigitalInput__, this );
    m_DigitalInputList.Add( WEDSTARTUP__DigitalInput__, WEDSTARTUP );
    
    THUSTARTUP = new Crestron.Logos.SplusObjects.DigitalInput( THUSTARTUP__DigitalInput__, this );
    m_DigitalInputList.Add( THUSTARTUP__DigitalInput__, THUSTARTUP );
    
    FRISTARTUP = new Crestron.Logos.SplusObjects.DigitalInput( FRISTARTUP__DigitalInput__, this );
    m_DigitalInputList.Add( FRISTARTUP__DigitalInput__, FRISTARTUP );
    
    SATSTARTUP = new Crestron.Logos.SplusObjects.DigitalInput( SATSTARTUP__DigitalInput__, this );
    m_DigitalInputList.Add( SATSTARTUP__DigitalInput__, SATSTARTUP );
    
    SUNSTARTUP = new Crestron.Logos.SplusObjects.DigitalInput( SUNSTARTUP__DigitalInput__, this );
    m_DigitalInputList.Add( SUNSTARTUP__DigitalInput__, SUNSTARTUP );
    
    MONSHUTDOWN = new Crestron.Logos.SplusObjects.DigitalInput( MONSHUTDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( MONSHUTDOWN__DigitalInput__, MONSHUTDOWN );
    
    TUESHUTDOWN = new Crestron.Logos.SplusObjects.DigitalInput( TUESHUTDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( TUESHUTDOWN__DigitalInput__, TUESHUTDOWN );
    
    WEDSHUTDOWN = new Crestron.Logos.SplusObjects.DigitalInput( WEDSHUTDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( WEDSHUTDOWN__DigitalInput__, WEDSHUTDOWN );
    
    THUSHUTDOWN = new Crestron.Logos.SplusObjects.DigitalInput( THUSHUTDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( THUSHUTDOWN__DigitalInput__, THUSHUTDOWN );
    
    FRISHUTDOWN = new Crestron.Logos.SplusObjects.DigitalInput( FRISHUTDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( FRISHUTDOWN__DigitalInput__, FRISHUTDOWN );
    
    SATSHUTDOWN = new Crestron.Logos.SplusObjects.DigitalInput( SATSHUTDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( SATSHUTDOWN__DigitalInput__, SATSHUTDOWN );
    
    SUNSHUTDOWN = new Crestron.Logos.SplusObjects.DigitalInput( SUNSHUTDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( SUNSHUTDOWN__DigitalInput__, SUNSHUTDOWN );
    
    SHUTDOWNOVERRIDE = new Crestron.Logos.SplusObjects.DigitalInput( SHUTDOWNOVERRIDE__DigitalInput__, this );
    m_DigitalInputList.Add( SHUTDOWNOVERRIDE__DigitalInput__, SHUTDOWNOVERRIDE );
    
    ENABLED = new Crestron.Logos.SplusObjects.DigitalOutput( ENABLED__DigitalOutput__, this );
    m_DigitalOutputList.Add( ENABLED__DigitalOutput__, ENABLED );
    
    AFTERHOUR = new Crestron.Logos.SplusObjects.DigitalOutput( AFTERHOUR__DigitalOutput__, this );
    m_DigitalOutputList.Add( AFTERHOUR__DigitalOutput__, AFTERHOUR );
    
    FORCEDONAFTERHOUR = new Crestron.Logos.SplusObjects.DigitalOutput( FORCEDONAFTERHOUR__DigitalOutput__, this );
    m_DigitalOutputList.Add( FORCEDONAFTERHOUR__DigitalOutput__, FORCEDONAFTERHOUR );
    
    TURNONPULSE = new Crestron.Logos.SplusObjects.DigitalOutput( TURNONPULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( TURNONPULSE__DigitalOutput__, TURNONPULSE );
    
    TURNOFFPULSE = new Crestron.Logos.SplusObjects.DigitalOutput( TURNOFFPULSE__DigitalOutput__, this );
    m_DigitalOutputList.Add( TURNOFFPULSE__DigitalOutput__, TURNOFFPULSE );
    
    SHUTDOWNWARNING = new Crestron.Logos.SplusObjects.DigitalOutput( SHUTDOWNWARNING__DigitalOutput__, this );
    m_DigitalOutputList.Add( SHUTDOWNWARNING__DigitalOutput__, SHUTDOWNWARNING );
    
    STARTUP_HOUR = new Crestron.Logos.SplusObjects.AnalogOutput( STARTUP_HOUR__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( STARTUP_HOUR__AnalogSerialOutput__, STARTUP_HOUR );
    
    STARTUP_MIN = new Crestron.Logos.SplusObjects.AnalogOutput( STARTUP_MIN__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( STARTUP_MIN__AnalogSerialOutput__, STARTUP_MIN );
    
    SHUTDOWN_HOUR = new Crestron.Logos.SplusObjects.AnalogOutput( SHUTDOWN_HOUR__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SHUTDOWN_HOUR__AnalogSerialOutput__, SHUTDOWN_HOUR );
    
    SHUTDOWN_MIN = new Crestron.Logos.SplusObjects.AnalogOutput( SHUTDOWN_MIN__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( SHUTDOWN_MIN__AnalogSerialOutput__, SHUTDOWN_MIN );
    
    DATE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( DATE__DOLLAR____AnalogSerialInput__, 16, this );
    m_StringInputList.Add( DATE__DOLLAR____AnalogSerialInput__, DATE__DOLLAR__ );
    
    DOW__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( DOW__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( DOW__DOLLAR____AnalogSerialOutput__, DOW__DOLLAR__ );
    
    MONSTARTUP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( MONSTARTUP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( MONSTARTUP__DOLLAR____AnalogSerialOutput__, MONSTARTUP__DOLLAR__ );
    
    TUESTARTUP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TUESTARTUP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TUESTARTUP__DOLLAR____AnalogSerialOutput__, TUESTARTUP__DOLLAR__ );
    
    WEDSTARTUP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( WEDSTARTUP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( WEDSTARTUP__DOLLAR____AnalogSerialOutput__, WEDSTARTUP__DOLLAR__ );
    
    THUSTARTUP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( THUSTARTUP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( THUSTARTUP__DOLLAR____AnalogSerialOutput__, THUSTARTUP__DOLLAR__ );
    
    FRISTARTUP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( FRISTARTUP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( FRISTARTUP__DOLLAR____AnalogSerialOutput__, FRISTARTUP__DOLLAR__ );
    
    SATSTARTUP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SATSTARTUP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( SATSTARTUP__DOLLAR____AnalogSerialOutput__, SATSTARTUP__DOLLAR__ );
    
    SUNSTARTUP__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SUNSTARTUP__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( SUNSTARTUP__DOLLAR____AnalogSerialOutput__, SUNSTARTUP__DOLLAR__ );
    
    MONSHUTDOWN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( MONSHUTDOWN__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( MONSHUTDOWN__DOLLAR____AnalogSerialOutput__, MONSHUTDOWN__DOLLAR__ );
    
    TUESHUTDOWN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TUESHUTDOWN__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( TUESHUTDOWN__DOLLAR____AnalogSerialOutput__, TUESHUTDOWN__DOLLAR__ );
    
    WEDSHUTDOWN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( WEDSHUTDOWN__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( WEDSHUTDOWN__DOLLAR____AnalogSerialOutput__, WEDSHUTDOWN__DOLLAR__ );
    
    THUSHUTDOWN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( THUSHUTDOWN__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( THUSHUTDOWN__DOLLAR____AnalogSerialOutput__, THUSHUTDOWN__DOLLAR__ );
    
    FRISHUTDOWN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( FRISHUTDOWN__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( FRISHUTDOWN__DOLLAR____AnalogSerialOutput__, FRISHUTDOWN__DOLLAR__ );
    
    SATSHUTDOWN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SATSHUTDOWN__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( SATSHUTDOWN__DOLLAR____AnalogSerialOutput__, SATSHUTDOWN__DOLLAR__ );
    
    SUNSHUTDOWN__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( SUNSHUTDOWN__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( SUNSHUTDOWN__DOLLAR____AnalogSerialOutput__, SUNSHUTDOWN__DOLLAR__ );
    
    
    SYSTEMISON.OnDigitalPush.Add( new InputChangeHandlerWrapper( SYSTEMISON_OnPush_0, false ) );
    SHUTDOWNOVERRIDE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SHUTDOWNOVERRIDE_OnPush_1, false ) );
    SYSTEMISON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( SYSTEMISON_OnRelease_2, false ) );
    ENABLETOGGLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLETOGGLE_OnPush_3, false ) );
    HOURUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOURUP_OnPush_4, false ) );
    HOURDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOURDOWN_OnPush_5, false ) );
    MINUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUP_OnPush_6, false ) );
    MINDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINDOWN_OnPush_7, false ) );
    MINUTETICK.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUTETICK_OnPush_8, false ) );
    DATE__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( DATE__DOLLAR___OnChange_9, false ) );
    MONSTARTUP.OnDigitalChange.Add( new InputChangeHandlerWrapper( MONSTARTUP_OnChange_10, false ) );
    TUESTARTUP.OnDigitalChange.Add( new InputChangeHandlerWrapper( TUESTARTUP_OnChange_11, false ) );
    WEDSTARTUP.OnDigitalChange.Add( new InputChangeHandlerWrapper( WEDSTARTUP_OnChange_12, false ) );
    THUSTARTUP.OnDigitalChange.Add( new InputChangeHandlerWrapper( THUSTARTUP_OnChange_13, false ) );
    FRISTARTUP.OnDigitalChange.Add( new InputChangeHandlerWrapper( FRISTARTUP_OnChange_14, false ) );
    SATSTARTUP.OnDigitalChange.Add( new InputChangeHandlerWrapper( SATSTARTUP_OnChange_15, false ) );
    SUNSTARTUP.OnDigitalChange.Add( new InputChangeHandlerWrapper( SUNSTARTUP_OnChange_16, false ) );
    MONSHUTDOWN.OnDigitalChange.Add( new InputChangeHandlerWrapper( MONSHUTDOWN_OnChange_17, false ) );
    TUESHUTDOWN.OnDigitalChange.Add( new InputChangeHandlerWrapper( TUESHUTDOWN_OnChange_18, false ) );
    WEDSHUTDOWN.OnDigitalChange.Add( new InputChangeHandlerWrapper( WEDSHUTDOWN_OnChange_19, false ) );
    THUSHUTDOWN.OnDigitalChange.Add( new InputChangeHandlerWrapper( THUSHUTDOWN_OnChange_20, false ) );
    FRISHUTDOWN.OnDigitalChange.Add( new InputChangeHandlerWrapper( FRISHUTDOWN_OnChange_21, false ) );
    SATSHUTDOWN.OnDigitalChange.Add( new InputChangeHandlerWrapper( SATSHUTDOWN_OnChange_22, false ) );
    SUNSHUTDOWN.OnDigitalChange.Add( new InputChangeHandlerWrapper( SUNSHUTDOWN_OnChange_23, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_WEEKLYSCHEDULE ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint SYSTEMISON__DigitalInput__ = 0;
const uint ENABLETOGGLE__DigitalInput__ = 1;
const uint MINUTETICK__DigitalInput__ = 2;
const uint HOURUP__DigitalInput__ = 3;
const uint HOURDOWN__DigitalInput__ = 4;
const uint MINUP__DigitalInput__ = 5;
const uint MINDOWN__DigitalInput__ = 6;
const uint MONSTARTUP__DigitalInput__ = 7;
const uint TUESTARTUP__DigitalInput__ = 8;
const uint WEDSTARTUP__DigitalInput__ = 9;
const uint THUSTARTUP__DigitalInput__ = 10;
const uint FRISTARTUP__DigitalInput__ = 11;
const uint SATSTARTUP__DigitalInput__ = 12;
const uint SUNSTARTUP__DigitalInput__ = 13;
const uint MONSHUTDOWN__DigitalInput__ = 14;
const uint TUESHUTDOWN__DigitalInput__ = 15;
const uint WEDSHUTDOWN__DigitalInput__ = 16;
const uint THUSHUTDOWN__DigitalInput__ = 17;
const uint FRISHUTDOWN__DigitalInput__ = 18;
const uint SATSHUTDOWN__DigitalInput__ = 19;
const uint SUNSHUTDOWN__DigitalInput__ = 20;
const uint SHUTDOWNOVERRIDE__DigitalInput__ = 21;
const uint DATE__DOLLAR____AnalogSerialInput__ = 0;
const uint ENABLED__DigitalOutput__ = 0;
const uint AFTERHOUR__DigitalOutput__ = 1;
const uint FORCEDONAFTERHOUR__DigitalOutput__ = 2;
const uint TURNONPULSE__DigitalOutput__ = 3;
const uint TURNOFFPULSE__DigitalOutput__ = 4;
const uint SHUTDOWNWARNING__DigitalOutput__ = 5;
const uint DOW__DOLLAR____AnalogSerialOutput__ = 0;
const uint STARTUP_HOUR__AnalogSerialOutput__ = 1;
const uint STARTUP_MIN__AnalogSerialOutput__ = 2;
const uint SHUTDOWN_HOUR__AnalogSerialOutput__ = 3;
const uint SHUTDOWN_MIN__AnalogSerialOutput__ = 4;
const uint MONSTARTUP__DOLLAR____AnalogSerialOutput__ = 5;
const uint TUESTARTUP__DOLLAR____AnalogSerialOutput__ = 6;
const uint WEDSTARTUP__DOLLAR____AnalogSerialOutput__ = 7;
const uint THUSTARTUP__DOLLAR____AnalogSerialOutput__ = 8;
const uint FRISTARTUP__DOLLAR____AnalogSerialOutput__ = 9;
const uint SATSTARTUP__DOLLAR____AnalogSerialOutput__ = 10;
const uint SUNSTARTUP__DOLLAR____AnalogSerialOutput__ = 11;
const uint MONSHUTDOWN__DOLLAR____AnalogSerialOutput__ = 12;
const uint TUESHUTDOWN__DOLLAR____AnalogSerialOutput__ = 13;
const uint WEDSHUTDOWN__DOLLAR____AnalogSerialOutput__ = 14;
const uint THUSHUTDOWN__DOLLAR____AnalogSerialOutput__ = 15;
const uint FRISHUTDOWN__DOLLAR____AnalogSerialOutput__ = 16;
const uint SATSHUTDOWN__DOLLAR____AnalogSerialOutput__ = 17;
const uint SUNSHUTDOWN__DOLLAR____AnalogSerialOutput__ = 18;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    [SplusStructAttribute(0, false, true)]
            public ushort SCHENABLED = 0;
            [SplusStructAttribute(1, false, true)]
            public ushort [] STARTUPHOUR;
            [SplusStructAttribute(2, false, true)]
            public ushort [] STARTUPMIN;
            [SplusStructAttribute(3, false, true)]
            public ushort [] SHUTDOWNHOUR;
            [SplusStructAttribute(4, false, true)]
            public ushort [] SHUTDOWNMIN;
            
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
