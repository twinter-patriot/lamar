using System;
using LamarCodeGeneration.Util;

namespace LamarCodeGeneration
{
    public class UnResolvableVariableException : Exception
    {
        public Type DependencyType { get; }
        public string VariableName { get; }
        public IGeneratedMethod Method { get; }
        
        public GeneratedType Type { get; set; }

        public UnResolvableVariableException(Type dependencyType, string variableName, IGeneratedMethod method)
        {
            DependencyType = dependencyType;
            VariableName = variableName;
            Method = method;
        }

        public UnResolvableVariableException(Type dependencyType, IGeneratedMethod method)
        {
            DependencyType = dependencyType;
            Method = method;
        }

        public override string Message
        {
            get
            {
                var methodName = Type == null ? Method.ToString() : $"{Type.TypeName}.{Method}";
                
                if (VariableName.IsNotEmpty())
                {
                    return
                        $"Lamar was unable to resolve a variable of type {DependencyType.FullNameInCode()} with name '{VariableName}' as part of the method {methodName}";
                }
                
                return $"Lamar was unable to resolve a variable of type {DependencyType.FullNameInCode()} as part of the method {methodName}";
            }
        }
    }
}