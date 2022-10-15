﻿using System;
using System.Reflection;

namespace Freedom
{
    public struct ClassMethod
    {
        public ClassMethod(String c, String m)
        {
            class_ = c;
            method = m;
        }

        public String class_ { get; set; }
        public String method { get; set; }
    }

    public class PreJit
    {
        public static int main(String pwzArgument)
        {
            var assembly = Assembly.GetEntryAssembly();
            Type[] classes = assembly.GetTypes();
            ClassMethod[] classmethods = new ClassMethod[]{
                new ClassMethod {class_ = "#=zkSWagGKhFAn55id$mbXyWWRyx_3V", method = "#=zZsW95$nuMw13"},
                new ClassMethod {class_ = "#=zLeUxSLKOhtnoyDCet1AKxC1Pft5nd98oNyBudgo=", method = "#=zBBJnU8bwZFe1luZf4A=="},
            };
            foreach (ClassMethod cm in classmethods)
            {
                foreach (Type class_ in classes)
                {
                    if (class_.Name == cm.class_)
                    {
                        MethodInfo[] methods = class_.GetMethods(
                                BindingFlags.DeclaredOnly |
                                BindingFlags.NonPublic |
                                BindingFlags.Public |
                                BindingFlags.Instance |
                                BindingFlags.Static);
                        foreach (MethodInfo method in methods)
                        {
                            if (method.Name == cm.method)
                            {
                                System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod(method.MethodHandle);
                                Console.WriteLine(String.Format("prejit {0}::{1}", cm.class_, cm.method));
                            }
                        }
                    }
                }
            }
            return 1;
        }
    }
}
