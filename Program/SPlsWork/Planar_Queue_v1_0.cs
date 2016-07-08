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

namespace UserModule_PLANAR_QUEUE_V1_0
{
    public class UserModuleClass_PLANAR_QUEUE_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput B;
        Crestron.Logos.SplusObjects.DigitalInput HOLD;
        Crestron.Logos.SplusObjects.BufferInput COMMAND;
        Crestron.Logos.SplusObjects.AnalogOutput A;
        Crestron.Logos.SplusObjects.StringOutput TX;
        public override object FunctionMain (  object __obj__ ) 
            { 
            short CODE = 0;
            
            CrestronString PACKET;
            PACKET  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            try
            {
                SplusExecutionContext __context__ = SplusFunctionMainStartCode();
                
                __context__.SourceCodeLine = 30;
                A  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 31;
                CODE = (short) ( WaitForInitializationComplete() ) ; 
                __context__.SourceCodeLine = 32;
                while ( Functions.TestForTrue  ( ( 1)  ) ) 
                    { 
                    __context__.SourceCodeLine = 34;
                    PACKET  .UpdateValue ( Functions.Gather ( "\r" , COMMAND )  ) ; 
                    __context__.SourceCodeLine = 35;
                    while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (A  .Value == 1) ) || Functions.TestForTrue ( Functions.BoolToInt (B  .Value == 1) )) ) ) || Functions.TestForTrue ( Functions.BoolToInt (HOLD  .Value == 1) )) ))  ) ) 
                        {
                        __context__.SourceCodeLine = 35;
                        Functions.Delay (  (int) ( 25 ) ) ; 
                        __context__.SourceCodeLine = 35;
                        }
                    
                    __context__.SourceCodeLine = 36;
                    TX  .UpdateValue ( PACKET  ) ; 
                    __context__.SourceCodeLine = 37;
                    A  .Value = (ushort) ( 1 ) ; 
                    __context__.SourceCodeLine = 32;
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            return __obj__;
            }
            
        
        public override void LogosSplusInitialize()
        {
            _SplusNVRAM = new SplusNVRAM( this );
            
            B = new Crestron.Logos.SplusObjects.DigitalInput( B__DigitalInput__, this );
            m_DigitalInputList.Add( B__DigitalInput__, B );
            
            HOLD = new Crestron.Logos.SplusObjects.DigitalInput( HOLD__DigitalInput__, this );
            m_DigitalInputList.Add( HOLD__DigitalInput__, HOLD );
            
            A = new Crestron.Logos.SplusObjects.AnalogOutput( A__AnalogSerialOutput__, this );
            m_AnalogOutputList.Add( A__AnalogSerialOutput__, A );
            
            TX = new Crestron.Logos.SplusObjects.StringOutput( TX__AnalogSerialOutput__, this );
            m_StringOutputList.Add( TX__AnalogSerialOutput__, TX );
            
            COMMAND = new Crestron.Logos.SplusObjects.BufferInput( COMMAND__AnalogSerialInput__, 2048, this );
            m_StringInputList.Add( COMMAND__AnalogSerialInput__, COMMAND );
            
            
            
            _SplusNVRAM.PopulateCustomAttributeList( true );
            
            NVRAM = _SplusNVRAM;
            
        }
        
        public override void LogosSimplSharpInitialize()
        {
            
            
        }
        
        public UserModuleClass_PLANAR_QUEUE_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
        
        
        
        
        const uint B__DigitalInput__ = 0;
        const uint HOLD__DigitalInput__ = 1;
        const uint COMMAND__AnalogSerialInput__ = 0;
        const uint A__AnalogSerialOutput__ = 0;
        const uint TX__AnalogSerialOutput__ = 1;
        
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
