// ReSharper disable InconsistentNaming

using System.CodeDom;
using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.CodeDom;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

namespace GhprMSTestTestContext.SpecFlowPlugin
{
    public class GhprMSTestSpecFlowGeneratorProvider : MsTest2010GeneratorProvider
    {
        public const string TestContextPrivateFieldName = "_testContext";
        public const string TestContextPublicPropertyName = "TestContext";

        public GhprMSTestSpecFlowGeneratorProvider(CodeDomHelper codeDomHelper) : base(codeDomHelper)
        {
        }

        public override void FinalizeTestClass(TestClassGenerationContext generationContext)
        {
            base.FinalizeTestClass(generationContext);

            /*generationContext.TestClass.Members.Add(new CodeMemberField
            {
                Attributes = MemberAttributes.Private | MemberAttributes.Final,
                Name = TestContextPrivateFieldName,
                Type = new CodeTypeReference(TESTCONTEXT_TYPE)
            });

            var msTestContextProperty = new CodeMemberProperty
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Type = new CodeTypeReference(TESTCONTEXT_TYPE),
                Name = TestContextPublicPropertyName,
                HasGet = true,
                HasSet = true
            };
            var testContextReferenceExpr = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), TestContextPrivateFieldName);
            msTestContextProperty.GetStatements.Add(new CodeMethodReturnStatement(testContextReferenceExpr));
            msTestContextProperty.SetStatements.Add(new CodeAssignStatement(testContextReferenceExpr, new CodePropertySetValueReferenceExpression()));
            generationContext.TestClass.Members.Add(msTestContextProperty);*/

            var msTestContextScenarioInitStatement =
                new CodeExpressionStatement(
                    new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("testRunner.ScenarioContext"),
                        "Add", new CodePrimitiveExpression(TestContextPublicPropertyName), new CodeArgumentReferenceExpression(TestContextPublicPropertyName)));
            generationContext.ScenarioInitializeMethod.Statements.Add(msTestContextScenarioInitStatement);

        }
    }
}