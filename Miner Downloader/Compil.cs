using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.CSharp;

namespace Miner_Downloader
{
    class Compil
    {
        public static void CompileParams(string source, string outPath, string frameVersion)
        {
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = true;
            cp.OutputAssembly = outPath;
            cp.CompilerOptions = "/optimize+ /platform:x86 /target:winexe";
            cp.TreatWarningsAsErrors = false;

            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("mscorlib.dll");
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            Dictionary<string, string> ProviderOptions = new Dictionary<string, string>();
            ProviderOptions.Add("CompilerVersion", frameVersion);

            CompilerResults compilerResults = new CSharpCodeProvider(ProviderOptions).CompileAssemblyFromSource(cp, source);

            if (compilerResults.Errors.Count > 0)
            {
                MessageBox.Show("Error occured while compiling.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                try
                {
                    IEnumerator enumerator = compilerResults.Errors.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        CompilerError compilerError = (CompilerError) enumerator.Current;
                        MessageBox.Show(compilerError.ErrorText);
                    }
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Miner built successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

